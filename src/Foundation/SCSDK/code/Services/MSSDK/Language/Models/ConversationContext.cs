using SitecoreCognitiveServices.Foundation.MSSDK;
using SitecoreCognitiveServices.Foundation.MSSDK.Language.Models.Luis;
using SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language.Factories;
using SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language.Models
{
    public class ConversationContext : IConversationContext
    {
        protected readonly IMicrosoftCognitiveServicesApiKeys ApiKeys;
        protected readonly IConversationFactory ConversationFactory;
        protected readonly IConversationHistory ConversationHistory;
        protected readonly IIntentProvider IntentProvider;

        public ConversationContext(
            IMicrosoftCognitiveServicesApiKeys apiKeys,
            IConversationFactory conversationFactory,
            IConversationHistory conversationHistory,
            IIntentProvider intentProvider)
        {
            ApiKeys = apiKeys;
            ConversationFactory = conversationFactory;
            ConversationHistory = conversationHistory;
            IntentProvider = intentProvider;
        }

        public Guid AppId { get; set; }
        public LuisResult Result { get; set; }
        public ItemContextParameters Parameters { get; set; }
        public string QuitIntentName { get; set; }
        public string FrustratedIntentName { get; set; }
        public string YesIntentName { get; set; }
        public string NoIntentName { get; set; }
        public string ClearText { get; set; }
        public string ConfirmText { get; set; }

        public virtual IConversation GetCurrentConversation()
        {
            var intent = IntentProvider.GetTopScoringIntent(this);

            IConversation conversation = null;

            var isConfident = Result.TopScoringIntent.Score > ApiKeys.LuisIntentConfidenceThreshold;
            var hasValidIntent = intent != null && isConfident;

            if (ConversationHistory.Conversations.Any())
            {
                conversation = ConversationHistory.Conversations.Last();
            }

            var inConversation = conversation != null && !conversation.IsEnded;

            if (!inConversation && hasValidIntent)
            {
                conversation = ConversationFactory.Create(Result, intent);
                ConversationHistory.Conversations.Add(conversation);
            }

            return conversation;
        }
    }
}