using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using SitecoreCognitiveServices.Foundation.LexSDK.Collection.Models;
using SitecoreCognitiveServices.Foundation.LexSDK.Http;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Collection
{
    public class CollectionRepository : ICollectionRepository
    {
        protected readonly ILexalyticsApiKeys ApiKeys;
        protected readonly ILexalyticsRepositoryClient RepositoryClient;

        public CollectionRepository(
            ILexalyticsApiKeys apiKeys,
            ILexalyticsRepositoryClient repositoryClient)
        {
            ApiKeys = apiKeys;
            RepositoryClient = repositoryClient;
        }

        public virtual int SendCollection(CollectionRequest collection, string configId = null, string jobId = null)
        {
            string url = RepositoryClient.BuildUrl(ApiKeys, "collection", configId);
            if (!string.IsNullOrEmpty(jobId))
            {
                var delimiter = string.IsNullOrWhiteSpace(configId) ? "?" : "&";
                url = $"{url}{delimiter}job_id={jobId}";
            }
            string data = JsonConvert.SerializeObject(collection);
            var response = RepositoryClient.PostStatus(url, data);

            return response;
        }

        public virtual CollectionAnalysis GetCollection(string id)
        {
            string encodedId = HttpUtility.UrlEncode(id);
            string url = RepositoryClient.BuildUrl(ApiKeys, $"collection/{encodedId}");
            var response = RepositoryClient.Get<CollectionAnalysis>(url);

            return response;
        }

        public virtual List<CollectionAnalysis> GetCollections(string configId = null, string jobId = null)
        {
            string url = RepositoryClient.BuildUrl(ApiKeys, "collection/processed", configId);
            if (!string.IsNullOrEmpty(jobId))
            {
                var delimiter = string.IsNullOrWhiteSpace(configId) ? "?" : "&";
                url = $"{url}{delimiter}job_id={jobId}";
            }
            var response = RepositoryClient.Get<List<CollectionAnalysis>>(url);

            return response;
        }

        public virtual int DeleteCollection(string id, string configId = null)
        {
            string encodedId = HttpUtility.UrlEncode(id);
            string url = RepositoryClient.BuildUrl(ApiKeys, $"collection/{encodedId}", configId);
            var response = RepositoryClient.Delete(url, null);
            
            return response;
        }
    }
}