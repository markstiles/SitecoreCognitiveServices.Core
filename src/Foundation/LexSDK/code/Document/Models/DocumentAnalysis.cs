using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Document.Models
{
    public class DocumentAnalysis
    {
        public string id { get; set; }
        public string config_id { get; set; }
        public string tag { get; set; }
        public string status { get; set; }
        public string source_text { get; set; }
        public string language { get; set; }
        public Metadata metadata { get; set; }
        public float language_score { get; set; }
        public float sentiment_score { get; set; }
        public string sentiment_polarity { get; set; }
        public string summary { get; set; }
        public Detail[] details { get; set; }
        public Phrase[] phrases { get; set; }
        public ModelSentiment model_sentiment { get; set; }
        public AutoCategories[] auto_categories { get; set; }
        public Theme[] themes { get; set; }
        public Entity[] entities { get; set; }
        public Relation[] relations { get; set; }
        public Opinion[] opinions { get; set; }
        public Topic[] topics { get; set; }
    }
}