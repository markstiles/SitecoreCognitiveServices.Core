using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.LexSDK.Query.Models;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.LexSDK
{
    public interface IQueryService
    {
        List<QueryItem> GetQueries(string configId = null);
        List<QueryItem> CreateQueries(List<QueryItem> items, string configId = null);
        List<QueryItem> UpdateQueries(List<QueryItem> items, string configId = null);
        int DeleteQueries(List<string> itemIds, string configId = null);
    }
}