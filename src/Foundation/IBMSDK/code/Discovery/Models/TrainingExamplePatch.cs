using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class TrainingExamplePatch
    {
        [JsonProperty("cross_reference", NullValueHandling = NullValueHandling.Ignore)]
        public string CrossReference { get; set; }
        [JsonProperty("relevance", NullValueHandling = NullValueHandling.Ignore)]
        public long? Relevance { get; set; }
    }
}
