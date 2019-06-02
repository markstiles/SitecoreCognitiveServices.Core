using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Collection.Models
{
    public class CollectionTheme
    {
        public string title { get; set; }
        public int phrases_count { get; set; }
        public int themes_count { get; set; }
        public float sentiment_score { get; set; }
        public string sentiment_polarity { get; set; }
        public CollectionMention[] mentions { get; set; }
    }
}