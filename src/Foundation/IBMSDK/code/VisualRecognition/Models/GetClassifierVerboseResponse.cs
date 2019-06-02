using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.VisualRecognition.Models
{
    public class GetClassifierVerboseResponse
    {
        public string classifier_id { get; set; }
        public string name { get; set; }
        public string owner { get; set; }
        public string status { get; set; }
        public string explanation { get; set; }
        public string created { get; set; }
        public List<ModelClass> classes { get; set; }
    }
}
