using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.LexSDK.Collection;
using SitecoreCognitiveServices.Foundation.LexSDK.Collection.Models;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.LexSDK
{
    public class CollectionService : ICollectionService
    {
        protected ICollectionRepository CollectionRepository;
        protected ILogWrapper Logger;

        public CollectionService(
            ICollectionRepository collectionRepository,
            ILogWrapper logger)
        {
            CollectionRepository = collectionRepository;
            Logger = logger;
        }
        
        public virtual int SendCollection(CollectionRequest collection, string configId = null, string jobId = null)
        {
            try
            {
                var result = CollectionRepository.SendCollection(collection, configId, jobId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("CollectionRepository.SendCollection failed", this, ex);
            }

            return -1;
        }

        public virtual CollectionAnalysis GetCollection(string id)
        {
            try
            {
                var result = CollectionRepository.GetCollection(id);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("CollectionRepository.GetCollection failed", this, ex);
            }

            return null;
        }

        public virtual List<CollectionAnalysis> GetCollections(string configId = null, string jobId = null)
        {
            try
            {
                var result = CollectionRepository.GetCollections(configId, jobId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("CollectionRepository.GetCollections failed", this, ex);
            }

            return null;
        }

        public virtual int DeleteCollection(string id, string configId = null)
        {
            try
            {
                var result = CollectionRepository.DeleteCollection(id, configId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("CollectionRepository.DeleteCollection failed", this, ex);
            }

            return -1;
        }

    }
}