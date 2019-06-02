using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Document.Models
{
    public class Topic
    {
        public string title { get; set; }
        public string type { get; set; }
        public int hitcount { get; set; }
        public float strength_score { get; set; }
        public float sentiment_score { get; set; }
        public string sentiment_polarity { get; set; }
    }
}