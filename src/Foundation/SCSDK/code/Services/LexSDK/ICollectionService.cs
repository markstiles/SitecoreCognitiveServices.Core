using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.LexSDK.Collection.Models;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.LexSDK
{
    public interface ICollectionService
    {
        int SendCollection(CollectionRequest collection, string configId = null, string jobId = null);
        CollectionAnalysis GetCollection(string id);
        List<CollectionAnalysis> GetCollections(string configId = null, string jobId = null);
        int DeleteCollection(string id, string configId = null);
    }
}