using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using SitecoreCognitiveServices.Foundation.LexSDK.Category.Models;
using SitecoreCognitiveServices.Foundation.LexSDK.Http;
using SitecoreCognitiveServices.Foundation.LexSDK.Http.Enums;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Category
{
    public class CategoryRepository : ICategoryRepository
    {
        protected readonly ILexalyticsApiKeys ApiKeys;
        protected readonly ILexalyticsRepositoryClient RepositoryClient;

        public CategoryRepository(
            ILexalyticsApiKeys apiKeys,
            ILexalyticsRepositoryClient repositoryClient)
        {
            ApiKeys = apiKeys;
            RepositoryClient = repositoryClient;
        }
        
        public virtual List<CategoryItem> ListCategories(string configId = null)
        {
            string url = RepositoryClient.BuildUrl(ApiKeys, "categories", configId);
            var response = RepositoryClient.Get<List<CategoryItem>>(url);

            return response;
        }

        public virtual List<CategoryItem> CreateCategories(List<CategoryItem> items, string configId = null)
        {
            string url = RepositoryClient.BuildUrl(ApiKeys, "categories", configId);
            var data = JsonConvert.SerializeObject(items);
            var response = RepositoryClient.Post<List<CategoryItem>>(url, data);

            return response;
        }

        public virtual List<CategoryItem> UpdateCategories(List<CategoryItem> items, string configId = null)
        {
            string url = RepositoryClient.BuildUrl(ApiKeys, "categories", configId);
            var data = JsonConvert.SerializeObject(items);
            var response = RepositoryClient.Put<List<CategoryItem>>(url, data);

            return response;
        }

        public virtual int DeleteCategories(List<CategoryItem> items, string configId = null)
        {
            string url = RepositoryClient.BuildUrl(ApiKeys, "categories", configId);
            var data = JsonConvert.SerializeObject(items);
            var response = RepositoryClient.Delete(url, data);

            return response;
        }
    }
}