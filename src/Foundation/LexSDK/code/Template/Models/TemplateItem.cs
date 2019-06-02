using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Template.Models
{
    public class TemplateItem
    {
        public bool auto_responding { get; set; }
        public float categories_threshold { get; set; }
        public int chars_threshold { get; set; }
        public TemplateCollection collection { get; set; }
        public string config_id { get; set; }
        public TemplateDocument document { get; set; }
        public int entities_threshold { get; set; }
        public bool is_primary { get; set; }
        public string language { get; set; }
        public int modified { get; set; }
        public string name { get; set; }
        public bool one_sentence { get; set; }
        public bool process_html { get; set; }
        public object[] rights { get; set; }
    }
}