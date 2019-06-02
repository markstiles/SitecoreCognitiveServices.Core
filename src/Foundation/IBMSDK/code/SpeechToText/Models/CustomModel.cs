using System;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.SpeechToText.Models
{
    public class CustomModel
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "base_model_name")]
        public string BaseModelName { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }
}