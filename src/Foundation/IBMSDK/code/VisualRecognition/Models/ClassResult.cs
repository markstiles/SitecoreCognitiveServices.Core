using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.VisualRecognition.Models
{
    public class ClassResult
    {
        [JsonProperty("class")]
        public string class_type { get; set; }
        public float score { get; set; }
        public string type_hierarchy { get; set; }
    }
}
