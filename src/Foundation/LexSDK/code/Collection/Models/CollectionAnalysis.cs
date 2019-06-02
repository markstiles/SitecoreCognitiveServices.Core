using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Collection.Models
{
    public class CollectionAnalysis
    {
        public string id { get; set; }
        public string config_id { get; set; }
        public string tag { get; set; }
        public string status { get; set; }
        public CollectionFacet[] facets { get; set; }
        public CollectionTheme[] themes { get; set; }
        public CollectionEntity[] entities { get; set; }
        public CollectionTopic[] topics { get; set; }
    }
}