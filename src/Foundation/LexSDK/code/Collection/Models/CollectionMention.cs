using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Collection.Models
{
    public class CollectionMention
    {
        public string label { get; set; }
        public bool is_negated { get; set; }
        public string negating_phrase { get; set; }
        public CollectionLocation[] locations { get; set; }
    }
}