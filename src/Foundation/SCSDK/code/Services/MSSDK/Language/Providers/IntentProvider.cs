using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language.Models;
using SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language.Factories;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language.Providers
{
    public class IntentProvider : IIntentProvider
    {
        private readonly Dictionary<Guid, Dictionary<string, IIntent>> _intentDictionary;
        protected readonly IConversationResponseFactory ConversationResponseFactory;

        public IntentProvider(
            IServiceProvider provider,
            IConversationResponseFactory responseFactory)
        {
            _intentDictionary = provider.GetServices<IIntent>()
                .Where(a => a.ApplicationId != Guid.Empty)
                .GroupBy(g => g.ApplicationId)
                .ToDictionary(a => a.Key, a => a.ToDictionary(b => b.KeyName));

            ConversationResponseFactory = responseFactory;
        }

        public Dictionary<string, IIntent> GetAllIntents(Guid appId)
        {
            if (!_intentDictionary.ContainsKey(appId))
                return null;

            return _intentDictionary[appId];
        }

        public IIntent GetIntent(Guid appId, string intentName)
        {
            var appDictionary = GetAllIntents(appId);
            if (appDictionary == null)
                return null;

            var caseSensitiveName = intentName.ToLower();

            return (appDictionary.ContainsKey(caseSensitiveName))
                ? appDictionary[caseSensitiveName]
                : null;
        }

        public IIntent GetTopScoringIntent(IConversationContext context)
        {
            return GetIntent(context.AppId, context.Result.TopScoringIntent.Intent);
        }

        public ConversationResponse GetDefaultResponse(Guid appId)
        {
            return GetIntent(appId, "none")?.Respond(null, null, null) ?? ConversationResponseFactory.Create();
        }
    }
}