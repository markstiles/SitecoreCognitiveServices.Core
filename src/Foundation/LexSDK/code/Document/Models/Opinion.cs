using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Document.Models
{
    public class Opinion
    {
        public string quotation { get; set; }
        public string type { get; set; }
        public string speaker { get; set; }
        public string topic { get; set; }
        public float sentiment_score { get; set; }
        public string sentiment_polarity { get; set; }
    }
}