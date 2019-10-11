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
        protected readonly IConversationResponseFactory ConversationResponseFactory;
        protected readonly IParameterResultFactory ResultFactory;

        protected string ReqParam = "RequestParam";
        protected string ReqConfirm = "RequestConfirm";

        public LuisConversationService(
            IIntentProvider intentProvider,
            IMicrosoftCognitiveServicesApiKeys apiKeys,
            IConversationResponseFactory responseFactory,
            IParameterResultFactory resultFactory)
        {
            IntentProvider = intentProvider;
            ApiKeys = apiKeys;
            ConversationResponseFactory = responseFactory;
            ResultFactory = resultFactory;
        }

        #endregion

        public virtual ConversationResponse ProcessUserInput(IConversationContext context)
        {
            if (string.IsNullOrWhiteSpace(context.Result.Query) || context.Result == null)
                return IntentProvider.GetDefaultResponse(context.AppId);

            // gather data
            var intent = IntentProvider.GetTopScoringIntent(context);
            var conversation = context.GetCurrentConversation();
            var isConfident = context.Result.TopScoringIntent.Score > ApiKeys.LuisIntentConfidenceThreshold;
            var hasValidIntent = intent != null && isConfident;
            var inConversation = conversation != null && !conversation.IsEnded;
            var requestedQuit = hasValidIntent && intent.KeyName.Equals(context.QuitIntentName);

            // if the user is trying to end or finish a conversation 
            if (inConversation && requestedQuit)
                return EndCurrentConversation(context);
                
            // continue conversation
            if (inConversation)
                return HandleCurrentConversation(context);
            
            // is a user frustrated or is their intention unclear
            var sentimentScore = context.Result.SentimentAnalysis?.score ?? 1;
            return (sentimentScore <= 0.4)
                ? IntentProvider.GetIntent(context.AppId, context.FrustratedIntentName)?.Respond(null, null, null) ?? IntentProvider.GetDefaultResponse(context.AppId)
                : IntentProvider.GetDefaultResponse(context.AppId);
        }
        
        public virtual ConversationResponse EndCurrentConversation(IConversationContext context)
        {
            context.GetCurrentConversation().IsEnded = true;

            return IntentProvider.GetTopScoringIntent(context)?.Respond(null, null, null) ?? IntentProvider.GetDefaultResponse(context.AppId);
        }

        public virtual ConversationResponse HandleCurrentConversation(IConversationContext context)
        {
            var conversation = context.GetCurrentConversation();

            var clear = $"{context.ClearText} ";
            if (context.Result.Query.StartsWith(clear))
            {
                var clearParam = context.Result.Query.Replace(clear, "");
                if (conversation.Data.ContainsKey(clearParam))
                    conversation.Data.Remove(clearParam);
            }

            // check and request all parameters of a conversation
            foreach (IConversationParameter p in conversation.Intent.ConversationParameters)
            {
                var vParameter = p as IValidationParameter;
                if (vParameter != null && !vParameter.IsValid(context))
                {
                    EndCurrentConversation(context);
                    return ConversationResponseFactory.Create(conversation.Intent.KeyName, p.GetParamMessage(conversation));
                }

                var rParam = p as IRequiredParameter;
                if (rParam == null)
                    continue;

                var parameterResult = LookupParam(rParam, context);
                if (!parameterResult.HasFailed)
                    continue;

                return RequestParam(rParam, conversation, context.Parameters, parameterResult.Error);
            }

            // save confirmation
            if (conversation.Intent.RequiresConfirmation
                && conversation.Data.ContainsKey(ReqConfirm)
                && context.Result.TopScoringIntent.Intent.Equals(context.YesIntentName, StringComparison.InvariantCultureIgnoreCase))
            {
                conversation.IsConfirmed = true;
                conversation.Data.Remove(ReqConfirm);
            }                

            // confirm selected options with user 
            if (conversation.Intent.RequiresConfirmation && !conversation.IsConfirmed)
            {
                conversation.Data[ReqConfirm] = new ParameterData { DisplayName = "confirm" };
                return ConversationResponseFactory.Create(conversation.Intent.KeyName, context.ConfirmText, conversation.IsEnded, "confirm", conversation.Data);
            }

            conversation.IsEnded = true;

            return conversation.Intent.Respond(context.Result, context.Parameters, conversation);
        }

        /// <summary>
        /// Create a response to the user requesting a specific parameter
        /// </summary>
        /// <param name="param">the parameter details</param>
        /// <param name="c">the conversation it occurs in</param>
        /// <param name="parameters">context parameters</param>
        /// <param name="message"></param>
        /// <returns></returns>
        public virtual ConversationResponse RequestParam(IRequiredParameter param, IConversation c, ItemContextParameters parameters, string message)
        {
            c.Data[ReqParam] = new ParameterData { DisplayName = param.ParamName };

            if (string.IsNullOrWhiteSpace(message))
                message = param.GetParamMessage(c);

            var intentInput = param.GetInput(parameters, c);
            return ConversationResponseFactory.Create(c.Intent.KeyName, message, c.IsEnded, intentInput);
        }

        /// <summary>
        /// get a valid parameter object by checking for it in the previously retrieved data store or by finding it based on the information provided by the user
        /// </summary>
        /// <param name="paramName">the parameter to retrieve</param>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual IParameterResult LookupParam(IRequiredParameter param, IConversationContext context)
        {
            var c = context.GetCurrentConversation();

            var storedValue = c.Data.ContainsKey(param.ParamName)
                ? c.Data[param.ParamName]
                : null;

            if (storedValue != null)
                return ResultFactory.GetSuccess(storedValue.DisplayName, storedValue.Value);

            string value = SearchUserValues(param.ParamName, context);
            if (string.IsNullOrEmpty(value))
                return ResultFactory.GetFailure();
            
            var paramResult = param.GetParameter(value, context);
            if (paramResult.HasFailed)
                return paramResult;
            
            if (IsParamRequest(param.ParamName, c)) // clear any request for this property
                c.Data.Remove(ReqParam);
            
            c.Data[param.ParamName] = new ParameterData { DisplayName = paramResult.DisplayName, Value = paramResult.DataValue };
            return ResultFactory.GetSuccess(paramResult.DisplayName, paramResult.DataValue);
        }

        /// <summary>
        /// tries to determine a value for the requested parameter from a number of possible locations; current response entities, current response, previously provided information (context), or previously provided entities
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual string SearchUserValues(string paramName, IConversationContext context)
        {
            var c = context.GetCurrentConversation();

            var paramAlignment = new Dictionary<string, string> {
                { "Date", "builtin.datetimeV2.datetime" }
            };
            
            if (IsParamRequest(paramName, c)) // was the user responding to a specific request
                return context.Result.Query;

            var entityType = paramAlignment.ContainsKey(paramName) ? paramAlignment[paramName] : paramName;
            var currentEntity = context.Result?.Entities?.FirstOrDefault(x => x.Type.Equals(entityType))?.Entity;
            if (currentEntity != null) // check the current request entities
                return currentEntity;
            
            if (c.Data.ContainsKey(paramName)) // check the context data
                return c.Data[paramName].DisplayName;

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
            return c.Data.ContainsKey(ReqParam) && c.Data[ReqParam].DisplayName.Equals(paramName);
        }
    }
}