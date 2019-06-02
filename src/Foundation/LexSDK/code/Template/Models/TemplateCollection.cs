using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Template.Models
{
    public class TemplateCollection
    {
        public int attribute_mentions_limit { get; set; }
        public int concept_topics_limit { get; set; }
        public int facet_atts_limit { get; set; }
        public int facet_mentions_limit { get; set; }
        public int facets_limit { get; set; }
        public int named_entities_limit { get; set; }
        public int named_mentions_limit { get; set; }
        public int query_topics_limit { get; set; }
        public int theme_mentions_limit { get; set; }
        public int themes_limit { get; set; }
        public int user_entities_limit { get; set; }
        public int user_mentions_limit { get; set; }
    }
}