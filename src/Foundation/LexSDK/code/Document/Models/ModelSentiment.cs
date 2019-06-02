using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Document.Models
{
    public class ModelSentiment
    {
        public string sentiment_polarity { get; set; }
        public string model_name { get; set; }
        public float mixed_score { get; set; }
        public float negative_score { get; set; }
        public float neutral_score { get; set; }
        public float positive_score { get; set; }
    }
}