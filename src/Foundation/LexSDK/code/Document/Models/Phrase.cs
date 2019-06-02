using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Document.Models
{
    public class Phrase
    {
        public string title { get; set; }
        public float sentiment_score { get; set; }
        public string sentiment_polarity { get; set; }
        public bool is_negated { get; set; }
        public string negating_phrase { get; set; }
        public bool is_intensified { get; set; }
        public string type { get; set; }
    }
}