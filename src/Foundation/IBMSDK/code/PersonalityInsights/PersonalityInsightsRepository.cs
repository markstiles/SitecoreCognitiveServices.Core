using System;
using SitecoreCognitiveServices.Foundation.IBMSDK.Http;
using SitecoreCognitiveServices.Foundation.IBMSDK.PersonalityInsights.Models;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.PersonalityInsights
{
    public class PersonalityInsightsRepository : IPersonalityInsightsRepository
    {
        #region Constructor

        protected static readonly string profileUrl = "profile";
        protected static readonly string versionDate = "2017-10-13";

        protected readonly IIBMWatsonApiKeys ApiKeys;
        protected readonly IIBMWatsonRepositoryClient RepositoryClient;

        public PersonalityInsightsRepository(
            IIBMWatsonApiKeys apiKeys,
            IIBMWatsonRepositoryClient repositoryClient)
        {
            ApiKeys = apiKeys;
            RepositoryClient = repositoryClient;
        }

        #endregion
        
        public Profile Profile(Content content, string contentType, string contentLanguage = null, string acceptLanguage = null, bool? rawScores = null, bool? csvHeaders = null, bool? consumptionPreferences = null)
        {
            if (content == null)
                throw new ArgumentNullException(nameof(content));
            if (string.IsNullOrEmpty(contentType))
                throw new ArgumentNullException(nameof(contentType));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null.");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.PersonalityInsightsUsername, ApiKeys.PersonalityInsightsPassword)
                                .PostAsync($"{ApiKeys.PersonalityInsightsEndpoint}{profileUrl}")
                                .WithArgument("version", versionDate)
                                .WithHeader("Content-Type", contentType)
                                .WithHeader("Content-Language", contentLanguage)
                                .WithHeader("Accept-Language", acceptLanguage)
                                .WithArgument("raw_scores", rawScores)
                                .WithArgument("csv_headers", csvHeaders)
                                .WithArgument("consumption_preferences", consumptionPreferences)
                                .WithBody<Content>(content)
                                .As<Profile>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }
    }
}