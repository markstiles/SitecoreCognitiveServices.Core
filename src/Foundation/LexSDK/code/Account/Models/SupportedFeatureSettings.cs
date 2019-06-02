using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Account.Models
{
    public class SupportedFeatureSettings
    {
        public bool blacklist { get; set; }
        public bool user_entities { get; set; }
        public bool sentiment_phrases { get; set; }
        public bool concept_topics { get; set; }
        public bool query_topics { get; set; }
    }
}