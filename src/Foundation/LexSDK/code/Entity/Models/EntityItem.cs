using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Entity.Models
{
    public class EntityItem
    {
        public string id { get; set; }
        public int modified { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string label { get; set; }
        public string normalized { get; set; }
    }
}