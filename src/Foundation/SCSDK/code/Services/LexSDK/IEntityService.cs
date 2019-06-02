using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.LexSDK.Entity.Models;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.LexSDK
{
    public interface IEntityService
    {
        List<EntityItem> GetEntities(string configId = null);
        List<EntityItem> CreateEntities(List<EntityItem> items, string configId = null);
        List<EntityItem> UpdateEntities(List<EntityItem> items, string configId = null);
        int DeleteEntities(List<string> itemIds, string configId = null);
    }
}