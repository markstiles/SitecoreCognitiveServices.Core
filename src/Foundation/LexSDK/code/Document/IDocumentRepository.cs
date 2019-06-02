using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.LexSDK.Document.Models;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Document
{
    public interface IDocumentRepository
    {
        int SendDocument(DocumentRequest doc, string configId = null);
        int SendDocuments(List<DocumentRequest> docs, string configId = null, string jobId = null);
        DocumentAnalysis GetDocument(string id, string configId = null);
        List<DocumentAnalysis> GetDocuments(string configId = null, string jobId = null);
        int DeleteDocument(string id, string configId = null);
    }
}