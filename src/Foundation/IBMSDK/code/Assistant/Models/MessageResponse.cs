using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Assistant.Models
{
    public class MessageResponse
    {
        [JsonProperty("input", NullValueHandling = NullValueHandling.Ignore)]
        public dynamic Input { get; set; }
        [JsonProperty("intents", NullValueHandling = NullValueHandling.Ignore)]
        public dynamic Intents { get; set; }
        [JsonProperty("entities", NullValueHandling = NullValueHandling.Ignore)]
        public dynamic Entities { get; set; }
        [JsonProperty("alternate_intents", NullValueHandling = NullValueHandling.Ignore)]
        public dynamic AlternateIntents { get; set; }
        [JsonProperty("context", NullValueHandling = NullValueHandling.Ignore)]
        public dynamic Context { get; set; }
        [JsonProperty("output", NullValueHandling = NullValueHandling.Ignore)]
        public dynamic Output { get; set; }
    }
}
