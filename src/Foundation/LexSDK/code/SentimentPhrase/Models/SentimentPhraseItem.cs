using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.LexSDK.SentimentPhrase.Models
{
    public class SentimentPhraseItem
    {
        public string id { get; set; }
        public int modified { get; set; }
        public string name { get; set; }
        public float weight { get; set; }
    }
}