using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using SitecoreCognitiveServices.Foundation.LexSDK.Account.Models;
using SitecoreCognitiveServices.Foundation.LexSDK.Http;
using SitecoreCognitiveServices.Foundation.LexSDK.Http.Enums;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Account
{
    public class AccountRepository : IAccountRepository
    {
        protected readonly ILexalyticsApiKeys ApiKeys;
        protected readonly ILexalyticsRepositoryClient RepositoryClient;

        public AccountRepository(
            ILexalyticsApiKeys apiKeys,
            ILexalyticsRepositoryClient repositoryClient)
        {
            ApiKeys = apiKeys;
            RepositoryClient = repositoryClient;
        }

        public virtual List<ServiceStatus> GetStatus()
        {
            string url = RepositoryClient.BuildUrl(ApiKeys, "status");
            var response = RepositoryClient.Get<List<ServiceStatus>>(url);

            return response;
        }

        public virtual Subscription GetSubscription()
        {
            string url = RepositoryClient.BuildUrl(ApiKeys, "subscription");
            var response = RepositoryClient.Get<Subscription>(url);

            return response;
        }

        public virtual List<Statistics> GetStatistics(string configId = null, string interval = null)
        {
            string url = RepositoryClient.BuildUrl(ApiKeys, "statistics", configId);
            if (!string.IsNullOrEmpty(interval))
            {
                var delimiter = string.IsNullOrWhiteSpace(configId) ? "?" : "&";
                url = $"{url}{delimiter}interval={interval}";
            }
            var response = RepositoryClient.Get<List<Statistics>>(url);

            return response;
        }

        public virtual List<SupportedFeatures> GetSupportedFeatures(string language = null)
        {
            var langParam = "";
            if (!string.IsNullOrEmpty(language))
                langParam = $"?language={language}";
            
            string url = $"{ApiKeys.Host}/features.{ApiKeys.Format}{langParam}";
            var response = RepositoryClient.Get<List<SupportedFeatures>>(url);

            return response;
        }
    }
}