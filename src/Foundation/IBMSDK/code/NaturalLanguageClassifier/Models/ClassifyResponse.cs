using System;
using System.Collections.Generic;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.NaturalLanguageClassifier.Models
{
    public class ClassifyResponse
    {
        public string classifier_id { get; set; }
        public string url { get; set; }
        public string text { get; set; }
        public string top_class { get; set; }
        public Classification[] classes { get; set; }
    }
}