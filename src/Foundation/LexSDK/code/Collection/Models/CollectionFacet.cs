using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Collection.Models
{
    public class CollectionFacet
    {
        public string label { get; set; }
        public int count { get; set; }
        public int negative_count { get; set; }
        public int positive_count { get; set; }
        public int neutral_count { get; set; }
        public CollectionAttribute[] attributes { get; set; }
        public CollectionMention[] mentions { get; set; }
    }
}