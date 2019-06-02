using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using SitecoreCognitiveServices.Foundation.LexSDK.Http;
using SitecoreCognitiveServices.Foundation.LexSDK.Http.Enums;
using SitecoreCognitiveServices.Foundation.LexSDK.SentimentPhrase.Models;

namespace SitecoreCognitiveServices.Foundation.LexSDK.SentimentPhrase
{
    public class SentimentPhraseRepository : ISentimentPhraseRepository
    {
        protected readonly ILexalyticsApiKeys ApiKeys;
        protected readonly ILexalyticsRepositoryClient RepositoryClient;

        public SentimentPhraseRepository(
            ILexalyticsApiKeys apiKeys,
            ILexalyticsRepositoryClient repositoryClient)
        {
            ApiKeys = apiKeys;
            RepositoryClient = repositoryClient;
        }

        public virtual List<SentimentPhraseItem> GetSentimentPhrases(string configId = null)
        {
            var url = RepositoryClient.BuildUrl(ApiKeys, "phrases", configId);
            var response = RepositoryClient.Get<List<SentimentPhraseItem>>(url);
            
            return response;
        }

        public virtual List<SentimentPhraseItem> CreateSentimentPhrases(List<SentimentPhraseItem> items, string configId = null)
        {
            var url = RepositoryClient.BuildUrl(ApiKeys, "phrases", configId);
            var data = JsonConvert.SerializeObject(items);
            var response = RepositoryClient.Post<List<SentimentPhraseItem>>(url, data);

            return response;
        }

        public virtual List<SentimentPhraseItem> UpdateSentimentPhrases(List<SentimentPhraseItem> items, string configId = null)
        {
            var url = RepositoryClient.BuildUrl(ApiKeys, "phrases", configId);
            var data = JsonConvert.SerializeObject(items);
            var response = RepositoryClient.Put<List<SentimentPhraseItem>>(url, data);

            return response;
        }

        public virtual int RemoveSentimentPhrases(List<SentimentPhraseItem> items, string configId = null)
        {
            var url = RepositoryClient.BuildUrl(ApiKeys, "phrases", configId);
            var data = JsonConvert.SerializeObject(items);
            var response = RepositoryClient.Delete(url, data);

            return response;
        }
    }
}