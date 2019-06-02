using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using SitecoreCognitiveServices.Foundation.LexSDK.Entity.Models;
using SitecoreCognitiveServices.Foundation.LexSDK.Http;
using SitecoreCognitiveServices.Foundation.LexSDK.Http.Enums;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Entity
{
    public class EntityRepository : IEntityRepository
    {
        protected readonly ILexalyticsApiKeys ApiKeys;
        protected readonly ILexalyticsRepositoryClient RepositoryClient;

        public EntityRepository(
            ILexalyticsApiKeys apiKeys,
            ILexalyticsRepositoryClient repositoryClient)
        {
            ApiKeys = apiKeys;
            RepositoryClient = repositoryClient;
        }

        public virtual List<EntityItem> GetEntities(string configId = null)
        {
            var url = RepositoryClient.BuildUrl(ApiKeys, "entities", configId);
            var response = RepositoryClient.Get<List<EntityItem>>(url);
            
            return response;
        }

        public virtual List<EntityItem> CreateEntities(List<EntityItem> items, string configId = null)
        {
            var url = RepositoryClient.BuildUrl(ApiKeys, "entities", configId);
            var data = JsonConvert.SerializeObject(items);
            var response = RepositoryClient.Post<List<EntityItem>>(url, data);

            return response;
        }

        public virtual List<EntityItem> UpdateEntities(List<EntityItem> items, string configId = null)
        {
            var url = RepositoryClient.BuildUrl(ApiKeys, "entities", configId);
            var data = JsonConvert.SerializeObject(items);
            var response = RepositoryClient.Put<List<EntityItem>>(url, data);

            return response;
        }

        public virtual int DeleteEntities(List<string> itemIds, string configId = null)
        {
            var url = RepositoryClient.BuildUrl(ApiKeys, "entities", configId);
            var data = JsonConvert.SerializeObject(itemIds);
            var response = RepositoryClient.Delete(url, data);

            return response;
        }
    }
}