using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using SitecoreCognitiveServices.Foundation.LexSDK.Document.Models;
using SitecoreCognitiveServices.Foundation.LexSDK.Http;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Document
{
    public class DocumentRepository : IDocumentRepository
    {
        protected readonly ILexalyticsApiKeys ApiKeys;
        protected readonly ILexalyticsRepositoryClient RepositoryClient;

        public DocumentRepository(
            ILexalyticsApiKeys apiKeys,
            ILexalyticsRepositoryClient repositoryClient)
        {
            ApiKeys = apiKeys;
            RepositoryClient = repositoryClient;
        }
        
        public virtual int SendDocument(DocumentRequest doc, string configId = null)
        {
            string url = RepositoryClient.BuildUrl(ApiKeys, "document", configId);
            string data = JsonConvert.SerializeObject(doc);
            int response = RepositoryClient.PostStatus(url, data);

            return response;
        }

        public virtual int SendDocuments(List<DocumentRequest> docs, string configId = null, string jobId = null)
        {
            string url = RepositoryClient.BuildUrl(ApiKeys, "document/batch", configId);
            if (!string.IsNullOrEmpty(jobId))
            {
                var delimiter = string.IsNullOrWhiteSpace(configId) ? "?" : "&";
                url = $"{url}{delimiter}job_id={jobId}";
            }
            string data = JsonConvert.SerializeObject(docs);
            int response = RepositoryClient.PostStatus(url, data);

            return response;
        }

        public virtual DocumentAnalysis GetDocument(string id, string configId = null)
        {
            string encodedId = HttpUtility.UrlEncode(id);
            string url = RepositoryClient.BuildUrl(ApiKeys, $"document/{encodedId}", configId);
            var response = RepositoryClient.Get<DocumentAnalysis>(url);
            
            return response;
        }

        public virtual List<DocumentAnalysis> GetDocuments(string configId = null, string jobId = null)
        {
            string url = RepositoryClient.BuildUrl(ApiKeys, "document/processed", configId);
            if (!string.IsNullOrEmpty(jobId))
            {
                var delimiter = string.IsNullOrWhiteSpace(configId) ? "?" : "&";
                url = $"{url}{delimiter}job_id={jobId}";
            }
            var response = RepositoryClient.Get<List<DocumentAnalysis>>(url);

            return response;
        }

        public virtual int DeleteDocument(string id, string configId = null)
        {
            string encodedId = HttpUtility.UrlEncode(id);
            string url = RepositoryClient.BuildUrl(ApiKeys, $"document/{encodedId}", configId);
            int status = RepositoryClient.Delete(url, null);
            
            return status;
        }
    }
}