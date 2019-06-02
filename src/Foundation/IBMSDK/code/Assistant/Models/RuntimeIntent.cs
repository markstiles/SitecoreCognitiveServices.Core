using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Assistant.Models
{
    public class RuntimeIntent
    {
        [JsonProperty("intent", NullValueHandling = NullValueHandling.Ignore)]
        public dynamic Intent { get; set; }
        [JsonProperty("confidence", NullValueHandling = NullValueHandling.Ignore)]
        public dynamic Confidence { get; set; }
    }
}
