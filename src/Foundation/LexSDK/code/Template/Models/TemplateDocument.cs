using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Template.Models
{
    public class TemplateDocument
    {
        public int auto_categories_limit { get; set; }
        public int concept_topics_limit { get; set; }
        public bool detect_language { get; set; }
        public int entity_themes_limit { get; set; }
        public bool intentions { get; set; }
        public bool model_sentiment { get; set; }
        public int named_entities_limit { get; set; }
        public int named_mentions_limit { get; set; }
        public int named_opinions_limit { get; set; }
        public int named_relations_limit { get; set; }
        public int phrases_limit { get; set; }
        public int possible_phrases_limit { get; set; }
        public int query_topics_limit { get; set; }
        public int summary_limit { get; set; }
        public int theme_mentions_limit { get; set; }
        public int themes_limit { get; set; }
        public int user_entities_limit { get; set; }
        public int user_mentions_limit { get; set; }
        public int user_opinions_limit { get; set; }
        public int user_relations_limit { get; set; }
    }
}