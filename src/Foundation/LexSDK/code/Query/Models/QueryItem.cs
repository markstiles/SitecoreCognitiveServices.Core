using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Query.Models
{
    public class QueryItem
    {
        public string id { get; set; }
        public int modified { get; set; }
        public string name { get; set; }
        public string query { get; set; }
    }
}