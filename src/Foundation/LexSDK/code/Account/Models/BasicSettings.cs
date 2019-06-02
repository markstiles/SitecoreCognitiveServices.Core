using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Account.Models
{
    public class BasicSettings
    {
        public int collection_limit { get; set; }
        public int auto_response_batch_limit { get; set; }
        public int configurations_limit { get; set; }
        public int concept_topics_limit { get; set; }
        public int query_topics_limit { get; set; }
        public int user_entities_limit { get; set; }
        public int callback_batch_limit { get; set; }
        public int concept_topic_samples_limit { get; set; }
        public bool return_source_text { get; set; }
        public int characters_limit { get; set; }
        public int blacklist_limit { get; set; }
        public int sentiment_phrases_limit { get; set; }
        public int incoming_batch_limit { get; set; }
        public int document_length { get; set; }
        public int polling_batch_limit { get; set; }
        public int summary_size_limit { get; set; }
    }
}