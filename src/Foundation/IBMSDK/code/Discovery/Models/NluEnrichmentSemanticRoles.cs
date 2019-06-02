using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class NluEnrichmentSemanticRoles
    {
        [JsonProperty("entities", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Entities { get; set; }
        [JsonProperty("keywords", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Keywords { get; set; }
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public long? Limit { get; set; }
    }
}
