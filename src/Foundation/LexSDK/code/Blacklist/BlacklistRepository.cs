using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using SitecoreCognitiveServices.Foundation.LexSDK.Account.Models;
using SitecoreCognitiveServices.Foundation.LexSDK.Blacklist.Models;
using SitecoreCognitiveServices.Foundation.LexSDK.Http;
using SitecoreCognitiveServices.Foundation.LexSDK.Http.Enums;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Blacklist
{
    public class BlacklistRepository : IBlacklistRepository
    {
        protected readonly ILexalyticsApiKeys ApiKeys;
        protected readonly ILexalyticsRepositoryClient RepositoryClient;

        public BlacklistRepository(
            ILexalyticsApiKeys apiKeys,
            ILexalyticsRepositoryClient repositoryClient)
        {
            ApiKeys = apiKeys;
            RepositoryClient = repositoryClient;
        }
        
        public virtual List<BlacklistItem> ListBlacklist(string configId = null)
        {
            string url = RepositoryClient.BuildUrl(ApiKeys, "blacklist", configId);
            var response = RepositoryClient.Get<List<BlacklistItem>>(url);

            return response;
        }

        public virtual int CreateBlacklistItem(List<string> items, string configId = null)
        {
            string url = RepositoryClient.BuildUrl(ApiKeys, "blacklist", configId);
            var data = JsonConvert.SerializeObject(items);
            var response = RepositoryClient.PostStatus(url, data);

            return response;
        }

        public virtual int UpdateBlacklistItem(List<string> items, string configId = null)
        {
            string url = RepositoryClient.BuildUrl(ApiKeys, "blacklist", configId);
            var data = JsonConvert.SerializeObject(items);
            var response = RepositoryClient.PutStatus(url, data);

            return response;
        }

        public virtual int DeleteBlacklistItem(List<string> items, string configId = null)
        {
            string url = RepositoryClient.BuildUrl(ApiKeys, "blacklist", configId);
            var data = JsonConvert.SerializeObject(items);
            var response = RepositoryClient.Delete(url, data);
            
            return response;
        }
    }
}