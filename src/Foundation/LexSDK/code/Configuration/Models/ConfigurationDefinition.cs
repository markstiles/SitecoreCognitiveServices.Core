using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Configuration.Models
{
    public class ConfigurationDefinition
    {
        public string name { get; set; }
        public string language { get; set; }
        public string config_id { get; set; }
        public bool is_primary { get; set; }
        public ConfigurationDocument document { get; set; }
        public bool auto_response { get; set; }
        public float concept_topics_threshold { get; set; }
        public int entities_threshold { get; set; }
        public ConfigurationCollection collection { get; set; }
        public bool process_html { get; set; }
        public int alphanumeric_threshold { get; set; }
        public float categories_threshold { get; set; }
        public bool one_sentence_mode { get; set; }
        public string callback { get; set; }
    }
}