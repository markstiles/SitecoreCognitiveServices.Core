using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Document.Models
{
    public class Word
    {
        public string tag { get; set; }
        public string type { get; set; }
        public string title { get; set; }
        public string stemmed { get; set; }
        public bool is_negated { get; set; }
        public float sentiment_score { get; set; }
    }
}