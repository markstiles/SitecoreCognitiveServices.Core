using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language.Enums;
using SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language.Models;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language.Factories
{
    public interface IConversationResponseFactory
    {
        ConversationResponse Create();
        ConversationResponse Create(string intent, string message);
        ConversationResponse Create(string intent, string message, bool conversationEnded);
        ConversationResponse Create(string intent, string message, bool conversationEnded, IntentInput options);
        ConversationResponse Create(string intent, string message, bool conversationEnded, string action);
        ConversationResponse Create(string intent, string message, bool conversationEnded, string action, Dictionary<string, ParameterData> selections);
    }

    public class ConversationResponseFactory : IConversationResponseFactory
    {
        protected readonly IIntentInputFactory IntentInputFactory;

        public ConversationResponseFactory(IIntentInputFactory inputFactory)
        {
            IntentInputFactory = inputFactory;
        }

        public ConversationResponse Create()
        {
            return Create("", "", true);
        }

        public ConversationResponse Create(string intent, string message)
        {
            return Create(intent, message, true);
        }

        public ConversationResponse Create(string intent, string message, bool conversationEnded)
        {
            return new ConversationResponse
            {
                Message = message,
                Ended = conversationEnded,
                Intent = intent,
                Action = string.Empty,
                Input = IntentInputFactory.Create(IntentInputType.None)
            };
        }

        public ConversationResponse Create(string intent, string message, bool conversationEnded, IntentInput options)
        {
            var response = Create(intent, message, conversationEnded);
            response.Input = options;

            return response;
        }

        public ConversationResponse Create(string intent, string message, bool conversationEnded, string action)
        {
            var response = Create(intent, message, conversationEnded);
            response.Action = action;
            response.Input = IntentInputFactory.Create(IntentInputType.None);

            return response;
        }

        public ConversationResponse Create(string intent, string message, bool conversationEnded, string action, Dictionary<string, ParameterData> selections)
        {
            var response = Create(intent, message, conversationEnded);
            response.Action = action;
            response.Input = IntentInputFactory.Create(IntentInputType.None);
            response.Selections = selections;

            return response;
        }
    }
}