using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using SitecoreCognitiveServices.Foundation.LexSDK.Configuration.Models;
using SitecoreCognitiveServices.Foundation.LexSDK.Http;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Configuration
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        protected readonly ILexalyticsApiKeys ApiKeys;
        protected readonly ILexalyticsRepositoryClient RepositoryClient;

        public ConfigurationRepository(
            ILexalyticsApiKeys apiKeys,
            ILexalyticsRepositoryClient repositoryClient)
        {
            ApiKeys = apiKeys;
            RepositoryClient = repositoryClient;
        }
        
        public virtual List<ConfigurationDefinition> ListConfigurations()
        {
            string url = RepositoryClient.BuildUrl(ApiKeys, "configurations");
            var response = RepositoryClient.Get<List<ConfigurationDefinition>>(url);

            return response;
        }

        public virtual int CreateConfigurations(List<ConfigurationDefinition> items)
        {
            var url = RepositoryClient.BuildUrl(ApiKeys, "configurations");
            var data = JsonConvert.SerializeObject(items);
            var response = RepositoryClient.PostStatus(url, data);

            return response;
        }

        public virtual int UpdateConfigurations(List<ConfigurationDefinition> items)
        {
            var url = RepositoryClient.BuildUrl(ApiKeys, "configurations");
            var data = JsonConvert.SerializeObject(items);
            var response = RepositoryClient.PutStatus(url, data);

            return response;
        }

        public virtual int CloneConfiguration(ConfigurationCloneRequest request)
        {
            var url = RepositoryClient.BuildUrl(ApiKeys, "configurations");
            var data = JsonConvert.SerializeObject(request);
            var response = RepositoryClient.PostStatus(url, data);

            return response;
        }

        public virtual int RemoveConfigurations(List<string> itemIds)
        {
            var url = RepositoryClient.BuildUrl(ApiKeys, "configurations");
            var data = JsonConvert.SerializeObject(itemIds);
            var response = RepositoryClient.Delete(url, data);

            return response;
        }
    }
}