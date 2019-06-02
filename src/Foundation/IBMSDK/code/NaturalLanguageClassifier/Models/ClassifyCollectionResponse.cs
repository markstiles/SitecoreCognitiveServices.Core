using System;
using System.Collections.Generic;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.NaturalLanguageClassifier.Models
{
    public class ClassifyCollectionResponse
    {
        public string classifier_id { get; set; }
        public string url { get; set; }
        public ClassificationCollection[] collection { get; set; }
    }
}