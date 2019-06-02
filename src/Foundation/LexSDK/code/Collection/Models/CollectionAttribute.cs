using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Collection.Models
{
    public class CollectionAttribute
    {
        public string label { get; set; }
        public int count { get; set; }
        public CollectionMention[] mentions { get; set; }
    }
}