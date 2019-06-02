using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Assistant.Models
{
    public class RuntimeEntity
    {
        [JsonProperty("entity", NullValueHandling = NullValueHandling.Ignore)]
        public dynamic Entity { get; set; }
        [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
        public dynamic Location { get; set; }
        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public dynamic Value { get; set; }
        [JsonProperty("confidence", NullValueHandling = NullValueHandling.Ignore)]
        public dynamic Confidence { get; set; }
        [JsonProperty("metadata", NullValueHandling = NullValueHandling.Ignore)]
        public dynamic Metadata { get; set; }
        [JsonProperty("groups", NullValueHandling = NullValueHandling.Ignore)]
        public dynamic Groups { get; set; }
    }
}
