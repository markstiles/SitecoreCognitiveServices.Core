using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.LexSDK.Entity.Models;
using SitecoreCognitiveServices.Foundation.LexSDK.Http;
using SitecoreCognitiveServices.Foundation.LexSDK.Http.Enums;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Entity
{
    public interface IEntityRepository
    {
        List<EntityItem> GetEntities(string configId = null);
        List<EntityItem> CreateEntities(List<EntityItem> items, string configId = null);
        List<EntityItem> UpdateEntities(List<EntityItem> items, string configId = null);
        int DeleteEntities(List<string> itemIds, string configId = null);
    }
}