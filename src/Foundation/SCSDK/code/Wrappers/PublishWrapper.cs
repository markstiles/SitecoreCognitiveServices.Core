using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Publishing;
using Sitecore.Globalization;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Wrappers
{
    public interface IPublishWrapper
    {
        Handle PublishItem(Item item, Database[] targets, Language[] languages, bool deep, bool compareRevisions, bool publishRelatedItems);
        List<ListItem> GetPublishingTargets(string dbName);
    }

    public class PublishWrapper : IPublishWrapper
    {
        protected readonly ISitecoreDataWrapper DataWrapper;

        public PublishWrapper(ISitecoreDataWrapper dataWrapper)
        {
            DataWrapper = dataWrapper;
        }

        public Handle PublishItem(Item item, Database[] targets, Language[] languages, bool deep, bool compareRevisions, bool publishRelatedItems) {
            return PublishManager.PublishItem(item, targets, languages, deep, compareRevisions, publishRelatedItems);
        }
        
        public List<ListItem> GetPublishingTargets(string dbName)
        {
            var db = DataWrapper.GetDatabase(dbName);

            var publishingTargetsItem = db.GetItem("/sitecore/system/publishing targets");
            return publishingTargetsItem?
                .GetChildren()
                .Select(child => new ListItem(child?.Fields["target database"]?.Value ?? string.Empty, child?.ID.ToString()))
                .ToList()
                ?? new List<ListItem>();
        }
    }
}