using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.VisualRecognition.Models
{
    public class ModelClass
    {
        [JsonProperty("class")]
        public string class_type { get; set; }
    }
}
