using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.LexSDK.Entity;
using SitecoreCognitiveServices.Foundation.LexSDK.Entity.Models;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.LexSDK
{
    public class EntityService : IEntityService
    {
        protected IEntityRepository EntityRepository;
        protected ILogWrapper Logger;

        public EntityService(
            IEntityRepository entityRepository,
            ILogWrapper logger)
        {
            EntityRepository = entityRepository;
            Logger = logger;
        }
        
        public virtual List<EntityItem> GetEntities(string configId = null)
        {
            try
            {
                var result = EntityRepository.GetEntities(configId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("EntityRepository.GetEntities failed", this, ex);
            }

            return null;
        }

        public virtual List<EntityItem> CreateEntities(List<EntityItem> items, string configId = null)
        {
            try
            {
                var result = EntityRepository.CreateEntities(items, configId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("EntityRepository.CreateEntities failed", this, ex);
            }

            return null;
        }

        public virtual List<EntityItem> UpdateEntities(List<EntityItem> items, string configId = null)
        {
            try
            {
                var result = EntityRepository.UpdateEntities(items, configId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("EntityRepository.UpdateEntities failed", this, ex);
            }

            return null;
        }

        public virtual int DeleteEntities(List<string> itemIds, string configId = null)
        {
            try
            {
                var result = EntityRepository.DeleteEntities(itemIds, configId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("EntityRepository.DeleteEntities failed", this, ex);
            }

            return -1;
        }
    }
}