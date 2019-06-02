using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.LexSDK.Document;
using SitecoreCognitiveServices.Foundation.LexSDK.Document.Models;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.LexSDK
{
    public class DocumentService : IDocumentService
    {
        protected IDocumentRepository DocumentRepository;
        protected ILogWrapper Logger;

        public DocumentService(
            IDocumentRepository documentRepository,
            ILogWrapper logger)
        {
            DocumentRepository = documentRepository;
            Logger = logger;
        }
        
        public virtual int SendDocument(DocumentRequest doc, string configId = null)
        {
            try
            {
                var result = DocumentRepository.SendDocument(doc, configId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DocumentRepository.SendDocument failed", this, ex);
            }

            return -1;
        }

        public virtual int SendDocuments(List<DocumentRequest> docs, string configId = null, string jobId = null)
        {
            try
            {
                var result = DocumentRepository.SendDocuments(docs, configId, jobId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DocumentRepository.SendDocuments failed", this, ex);
            }

            return -1;
        }

        public virtual DocumentAnalysis GetDocument(string id, string configId = null)
        {
            try
            {
                var result = DocumentRepository.GetDocument(id, configId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DocumentRepository.GetDocument failed", this, ex);
            }

            return null;
        }

        public virtual List<DocumentAnalysis> GetDocuments(string configId = null, string jobId = null)
        {
            try
            {
                var result = DocumentRepository.GetDocuments(configId, jobId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DocumentRepository.GetDocuments failed", this, ex);
            }

            return null;
        }

        public virtual int DeleteDocument(string id, string configId = null)
        {
            try
            {
                var result = DocumentRepository.DeleteDocument(id, configId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DocumentRepository.DeleteDocument failed", this, ex);
            }

            return -1;
        }
    }
}