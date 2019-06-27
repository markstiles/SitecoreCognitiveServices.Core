using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.MSSDK;
using SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language.Models;
using SitecoreCognitiveServices.Foundation.MSSDK.Language.Models.Luis;
using SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language.Factories;
using SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language.Providers;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language
{   
    public class LuisConversationService : ILuisConversationService
    {
        #region constructor 

        protected readonly IIntentProvider IntentProvider;
        protected readonly IMicrosoftCognitiveServicesApiKeys ApiKeys;
        protected readonly IConversationHistory ConversationHistory;
        protected readonly IConversationFactory ConversationFactory;
        protected readonly IConversationResponseFactory ConversationResponseFactory;
        protected readonly IParameterResultFactory ResultFactory;

        protected string ReqParam = "RequestParam";

        public LuisConversationService(
            IIntentProvider intentProvider,
            IMicrosoftCognitiveServicesApiKeys apiKeys,
            IConversationHistory convoHistory,
            IConversationFactory convoFactory,
            IConversationResponseFactory responseFactory,
            IParameterResultFactory resultFactory)
        {
            IntentProvider = intentProvider;
            ApiKeys = apiKeys;
            ConversationHistory = convoHistory;
            ConversationFactory = convoFactory;
            ConversationResponseFactory = responseFactory;
            ResultFactory = resultFactory;
        }

        #endregion

        public ConversationResponse HandleMessage(IConversationContext context)
        {
            if (string.IsNullOrWhiteSpace(context.Message) || context.Result == null)
                return IntentProvider.GetDefaultResponse(context.AppId);

            IConversation conversation = (ConversationHistory.Conversations.Any())
                ? ConversationHistory.Conversations.Last()
                : null;
        
            var intent = IntentProvider.GetIntent(context.AppId, context.Result.TopScoringIntent.Intent);
            var isConfident = context.Result.TopScoringIntent.Score > ApiKeys.LuisIntentConfidenceThreshold;
            var hasValidIntent = intent != null && isConfident;
            var inConversation = conversation != null && !conversation.IsEnded;
            var requestedQuit = hasValidIntent && intent.Name.Equals(context.QuitIntentName);

            // if the user is trying to end or finish a conversation 
            if (inConversation && requestedQuit)
                return EndConversation(conversation, intent, context.AppId);
            
            // start a new conversation if not in one
            if (!inConversation && hasValidIntent)
            {
                conversation = ConversationFactory.Create(context.Result, intent);
                ConversationHistory.Conversations.Add(conversation);
                inConversation = true;
            }
                
            // continue conversation
            if (inConversation)
                return HandleConversation(conversation, context);

            // is a user frustrated or is their intention unclear
            var sentimentScore = context.Result.SentimentAnalysis?.score ?? 1;
            return (sentimentScore <= 0.4)
                ? IntentProvider.GetIntent(context.AppId, context.FrustratedUserIntentName)?.Respond(null, null, null) ?? IntentProvider.GetDefaultResponse(context.AppId)
                : IntentProvider.GetDefaultResponse(context.AppId);
        }
        
        public ConversationResponse EndConversation(IConversation conversation, IIntent intent, Guid appId)
        {
            conversation.IsEnded = true;

            return intent?.Respond(null, null, null) ?? IntentProvider.GetDefaultResponse(appId);
        }

        public ConversationResponse HandleConversation(IConversation conversation, IConversationContext context)
        {
            var clear = $"{context.ClearText} ";
            if (context.Message.StartsWith(clear))
            {
                var clearParam = context.Message.Replace(clear, "");
                if (conversation.Context.ContainsKey(clearParam))
                    conversation.Context.Remove(clearParam);
                if (conversation.Data.ContainsKey(clearParam))
                    conversation.Data.Remove(clearParam);
            }

            // check and request all required parameters of a conversation
            foreach (IRequiredConversationParameter p in conversation.Intent.ConversationParameters)
            {
                var parameterResult = TryGetParam(p, context.Result, conversation, context.Parameters);
                if (!parameterResult.HasFailed)
                    continue;

                return RequestParam(p, conversation, context.Parameters, parameterResult.Error);
            }

            // save confirmation
            if (conversation.Intent.RequiresConfirmation
                && context.Message.Equals(context.AcceptText, StringComparison.InvariantCultureIgnoreCase))
                conversation.IsConfirmed = true;

            // confirm selected options with user 
            if (conversation.Intent.RequiresConfirmation && !conversation.IsConfirmed)
                return ConversationResponseFactory.Create(conversation.Intent.Name, context.ConfirmText, conversation.IsEnded, "confirm", conversation.Context);

            conversation.IsEnded = true;

            return conversation.Intent.Respond(context.Result, context.Parameters, conversation);
        }
        
        /// <summary>
        /// get a valid parameter object by checking for it in the previously retrieved data store or by finding it based on the information provided by the user
        /// </summary>
        /// <param name="paramName">the parameter to retrieve</param>
        /// <param name="result">the luis response that provides intent and entity information provided by the user</param>
        /// <param name="c">the current conversation</param>
        /// <param name="parameters">the context paramters</param>
        /// <param name="GetValidParameter">the method that can retrieve the valid parameters for a valid user input</param>
        /// <returns></returns>
        public virtual IParameterResult TryGetParam(IRequiredConversationParameter param, LuisResult result, IConversation c, ItemContextParameters parameters)
        {
            var storedValue = c.Data.ContainsKey(param.ParamName)
                ? c.Data[param.ParamName]
                : null;

            if (storedValue != null)
                return ResultFactory.GetSuccess(storedValue);

            string value = GetUserValue(param.ParamName, result, c);
            if (string.IsNullOrEmpty(value))
                return ResultFactory.GetFailure();
            
            var paramResult = param.GetParameter(value, parameters, c);
            if (paramResult.HasFailed)
                return paramResult;
            
            if (IsParamRequest(param.ParamName, c)) // clear any request for this property
                c.Context.Remove(ReqParam);

            c.Context[param.ParamName] = value;
            c.Data[param.ParamName] = paramResult.ReturnValue;
            return ResultFactory.GetSuccess(paramResult.ReturnValue);
        }

        /// <summary>
        /// tries to determine a value for the requested parameter from a number of possible locations; current response entities, current response, previously provided information (context), or previously provided entities
        /// </summary>
        /// <param name="paramName">the parameter to be searching for</param>
        /// <param name="result">the luis query result that identities the intent and entities</param>
        /// <param name="c">the current conversation</param>
        /// <returns></returns>
        public virtual string GetUserValue(string paramName, LuisResult result, IConversation c)
        {
            var paramAlignment = new Dictionary<string, string> {
                { "Date", "builtin.datetimeV2.datetime" }
            };
            
            if (IsParamRequest(paramName, c)) // was the user responding to a specific request
                return result.Query;

            var entityType = paramAlignment.ContainsKey(paramName) ? paramAlignment[paramName] : paramName;
            var currentEntity = result?.Entities?.FirstOrDefault(x => x.Type.Equals(entityType))?.Entity;
            if (currentEntity != null) // check the current request entities
                return currentEntity;
            
            if (c.Context.ContainsKey(paramName)) // check the context data
                return c.Context[paramName];

            var initialEntity = c.Result?.Entities?.FirstOrDefault(x => x.Type.Equals(entityType))?.Entity;
            if (initialEntity != null) // check the initial request entities
                return initialEntity;

            return string.Empty;
        }

        /// <summary>
        /// Is the currently requested parameter the one I'm checking
        /// </summary>
        /// <param name="paramName">the parameter to check</param>
        /// <param name="c">the conversation it's occurring in</param>
        /// <returns></returns>
        public virtual bool IsParamRequest(string paramName, IConversation c)
        {
            return c.Context.ContainsKey(ReqParam) && c.Context[ReqParam].Equals(paramName);
        }

        /// <summary>
        /// Create a response to the user requesting a specific parameter
        /// </summary>
        /// <param name="param">the parameter details</param>
        /// <param name="c">the conversation it occurs in</param>
        /// <param name="parameters">context parameters</param>
        /// <returns></returns>
        public virtual ConversationResponse RequestParam(IRequiredConversationParameter param, IConversation c, ItemContextParameters parameters, string message)
        {
            c.Context[ReqParam] = param.ParamName;

            if (string.IsNullOrWhiteSpace(message))
                message = param.ParamMessage;

            return ConversationResponseFactory.Create(c.Intent.Name, message, c.IsEnded, param.GetInput(parameters, c));
        }
    }
}