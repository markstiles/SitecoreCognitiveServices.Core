using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.VisualRecognition.Models
{
    public class ClassifyPerClassifier
    {
        public string name { get; set; }
        public string classifier_id { get; set; }
        public List<ClassResult> classes { get; set; }
    }
}
