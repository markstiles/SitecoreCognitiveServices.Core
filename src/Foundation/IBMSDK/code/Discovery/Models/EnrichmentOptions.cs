using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class EnrichmentOptions
    {
        [JsonProperty("features", NullValueHandling = NullValueHandling.Ignore)]
        public NluEnrichmentFeatures Features { get; set; }
        [JsonProperty("model", NullValueHandling = NullValueHandling.Ignore)]
        public string Model { get; set; }
    }
}
