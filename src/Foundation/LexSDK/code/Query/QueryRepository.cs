using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using SitecoreCognitiveServices.Foundation.LexSDK.Http;
using SitecoreCognitiveServices.Foundation.LexSDK.Query.Models;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Query
{
    public class QueryRepository : IQueryRepository
    {
        protected readonly ILexalyticsApiKeys ApiKeys;
        protected readonly ILexalyticsRepositoryClient RepositoryClient;

        public QueryRepository(
            ILexalyticsApiKeys apiKeys,
            ILexalyticsRepositoryClient repositoryClient)
        {
            ApiKeys = apiKeys;
            RepositoryClient = repositoryClient;
        }

        public virtual List<QueryItem> GetQueries(string configId = null)
        {
            var url = RepositoryClient.BuildUrl(ApiKeys, "queries", configId);
            var response = RepositoryClient.Get<List<QueryItem>>(url);
            
            return response;
        }

        public virtual List<QueryItem> CreateQueries(List<QueryItem> items, string configId = null)
        {
            var url = RepositoryClient.BuildUrl(ApiKeys, "queries", configId);
            var data = JsonConvert.SerializeObject(items);
            var response = RepositoryClient.Post<List<QueryItem>>(url, data);

            return response;
        }

        public virtual List<QueryItem> UpdateQueries(List<QueryItem> items, string configId = null)
        {
            var url = RepositoryClient.BuildUrl(ApiKeys, "queries", configId);
            var data = JsonConvert.SerializeObject(items);
            var response = RepositoryClient.Put<List<QueryItem>>(url, data);

            return response;
        }

        public virtual int DeleteQueries(List<string> itemIds, string configId = null)
        {
            var url = RepositoryClient.BuildUrl(ApiKeys, "queries", configId);
            var data = JsonConvert.SerializeObject(itemIds);
            var response = RepositoryClient.Delete(url, data);

            return response;
        }
    }
}