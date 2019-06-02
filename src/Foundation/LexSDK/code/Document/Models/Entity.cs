using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Document.Models
{
    public class Entity
    {
        public string type { get; set; }
        public int evidence { get; set; }
        public bool confident { get; set; }
        public bool is_about { get; set; }
        public string entity_type { get; set; }
        public string title { get; set; }
        public string label { get; set; }
        public float sentiment_score { get; set; }
        public string sentiment_polarity { get; set; }
        public Mention[] mentions { get; set; }
        public Theme[] themes { get; set; }
    }
}