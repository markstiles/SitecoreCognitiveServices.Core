using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class NluEnrichmentFeatures
    {
        [JsonProperty("keywords", NullValueHandling = NullValueHandling.Ignore)]
        public NluEnrichmentKeywords Keywords { get; set; }
        [JsonProperty("entities", NullValueHandling = NullValueHandling.Ignore)]
        public NluEnrichmentEntities Entities { get; set; }
        [JsonProperty("sentiment", NullValueHandling = NullValueHandling.Ignore)]
        public NluEnrichmentSentiment Sentiment { get; set; }
        [JsonProperty("emotion", NullValueHandling = NullValueHandling.Ignore)]
        public NluEnrichmentEmotion Emotion { get; set; }
        [JsonProperty("categories", NullValueHandling = NullValueHandling.Ignore)]
        public NluEnrichmentCategories Categories { get; set; }
        [JsonProperty("semantic_roles", NullValueHandling = NullValueHandling.Ignore)]
        public NluEnrichmentSemanticRoles SemanticRoles { get; set; }
        [JsonProperty("relations", NullValueHandling = NullValueHandling.Ignore)]
        public NluEnrichmentRelations Relations { get; set; }
    }
}
