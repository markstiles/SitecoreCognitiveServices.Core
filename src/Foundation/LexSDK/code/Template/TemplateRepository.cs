using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using SitecoreCognitiveServices.Foundation.LexSDK.Http;
using SitecoreCognitiveServices.Foundation.LexSDK.Template.Models;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Template
{
    public class TemplateRepository : ITemplateRepository
    {
        protected readonly ILexalyticsApiKeys ApiKeys;
        protected readonly ILexalyticsRepositoryClient RepositoryClient;

        public TemplateRepository(
            ILexalyticsApiKeys apiKeys,
            ILexalyticsRepositoryClient repositoryClient)
        {
            ApiKeys = apiKeys;
            RepositoryClient = repositoryClient;
        }

        public virtual List<TemplateItem> GetTemplates(string configId = null)
        {
            var url = RepositoryClient.BuildUrl(ApiKeys, "templates", configId);
            var response = RepositoryClient.Get<List<TemplateItem>>(url);

            return response;
        }
    }
}