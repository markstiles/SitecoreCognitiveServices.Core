using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.LexSDK.Query;
using SitecoreCognitiveServices.Foundation.LexSDK.Query.Models;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.LexSDK
{
    public class QueryService : IQueryService
    {
        protected IQueryRepository QueryRepository;
        protected ILogWrapper Logger;

        public QueryService(
            IQueryRepository queryRepository,
            ILogWrapper logger)
        {
            QueryRepository = queryRepository;
            Logger = logger;
        }
        
        public virtual List<QueryItem> GetQueries(string configId = null)
        {
            try
            {
                var result = QueryRepository.GetQueries(configId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("QueryRepository.GetQueries failed", this, ex);
            }

            return null;
        }

        public virtual List<QueryItem> CreateQueries(List<QueryItem> items, string configId = null)
        {
            try
            {
                var result = QueryRepository.CreateQueries(items, configId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("QueryRepository.CreateQueries failed", this, ex);
            }

            return null;
        }

        public virtual List<QueryItem> UpdateQueries(List<QueryItem> items, string configId = null)
        {
            try
            {
                var result = QueryRepository.UpdateQueries(items, configId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("QueryRepository.UpdateQueries failed", this, ex);
            }

            return null;
        }

        public virtual int DeleteQueries(List<string> itemIds, string configId = null)
        {
            try
            {
                var result = QueryRepository.DeleteQueries(itemIds, configId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("QueryRepository.DeleteQueries failed", this, ex);
            }

            return -1;
        }
    }
}