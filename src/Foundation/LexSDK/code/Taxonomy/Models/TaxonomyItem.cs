using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Taxonomy.Models
{
    public class TaxonomyItem
    {
        public string id { get; set; }
        public string name { get; set; }
        public int timestamp { get; set; }
        public TaxonomyTopic[] topics { get; set; }
    }
}