using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Account.Models
{
    public class DiscoveryMode
    {
        public bool named_entities { get; set; }
        public bool mentions { get; set; }
        public bool facets { get; set; }
        public bool user_entities { get; set; }
        public bool concept_topics { get; set; }
        public bool themes { get; set; }
        public bool query_topics { get; set; }
        public bool attributes { get; set; }
    }
}