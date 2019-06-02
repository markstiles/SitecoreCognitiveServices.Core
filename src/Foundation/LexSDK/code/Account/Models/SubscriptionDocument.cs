using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Account.Models
{
    public class SubscriptionDocument
    {
        public bool concept_topics { get; set; }
        public bool query_topics { get; set; }
        public bool sentiment_phrases { get; set; }
        public bool user_entities { get; set; }
        public bool intentions { get; set; }
        public bool model_sentiment { get; set; }
        public bool language_detection { get; set; }
        public bool named_entities { get; set; }
        public bool pos_tagging { get; set; }
        public bool summary { get; set; }
        public bool themes { get; set; }
        public bool relations { get; set; }
        public bool mentions { get; set; }
        public bool opinions { get; set; }
        public bool auto_categories { get; set; }
    }
}