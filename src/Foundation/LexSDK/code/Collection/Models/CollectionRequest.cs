using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Collection.Models
{
    public class CollectionRequest
    {
        public string id { get; set; }
        public string tag { get; set; }
        public string[] documents { get; set; }
    }
}