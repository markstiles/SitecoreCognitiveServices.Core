using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Document.Models
{
    public class Theme
    {
        public int evidence { get; set; }
        public bool is_about { get; set; }
        public float strength_score { get; set; }
        public float sentiment_score { get; set; }
        public string sentiment_polarity { get; set; }
        public string title { get; set; }
        public Mention[] mentions { get; set; }
    }
}