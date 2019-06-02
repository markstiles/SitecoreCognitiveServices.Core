using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using SitecoreCognitiveServices.Foundation.LexSDK.Http;
using SitecoreCognitiveServices.Foundation.LexSDK.Taxonomy.Models;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Taxonomy
{
    public class TaxonomyRepository : ITaxonomyRepository
    {
        protected readonly ILexalyticsApiKeys ApiKeys;
        protected readonly ILexalyticsRepositoryClient RepositoryClient;

        public TaxonomyRepository(
            ILexalyticsApiKeys apiKeys,
            ILexalyticsRepositoryClient repositoryClient)
        {
            ApiKeys = apiKeys;
            RepositoryClient = repositoryClient;
        }

        public virtual List<TaxonomyItem> GetTaxonomies(string configId = null)
        {
            var url = RepositoryClient.BuildUrl(ApiKeys, "taxonomy", configId);
            var response = RepositoryClient.Get<List<TaxonomyItem>>(url);

            return response;
        }

        public virtual List<TaxonomyItem> CreateTaxonomies(List<TaxonomyItem> items, string configId = null)
        {
            var url = RepositoryClient.BuildUrl(ApiKeys, "taxonomy", configId);
            var data = JsonConvert.SerializeObject(items);
            var response = RepositoryClient.Post<List<TaxonomyItem>>(url, data);

            return response;
        }

        public virtual List<TaxonomyItem> UpdateTaxonomy(List<TaxonomyItem> items, string configId = null)
        {
            var url = RepositoryClient.BuildUrl(ApiKeys, "taxonomy", configId);
            var data = JsonConvert.SerializeObject(items);
            var response = RepositoryClient.Put<List<TaxonomyItem>>(url, data);

            return response;
        }

        public virtual int DeleteTaxonomy(List<string> itemIds, string configId = null)
        {
            var url = RepositoryClient.BuildUrl(ApiKeys, "taxonomy", configId);
            var data = JsonConvert.SerializeObject(itemIds);
            var response = RepositoryClient.Delete(url, data);

            return response;
        }
    }
}