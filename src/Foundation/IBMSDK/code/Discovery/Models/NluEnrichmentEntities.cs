using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class NluEnrichmentEntities
    {
        [JsonProperty("sentiment", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Sentiment { get; set; }
        [JsonProperty("emotion", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Emotion { get; set; }
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public long? Limit { get; set; }
        [JsonProperty("mentions", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Mentions { get; set; }
        [JsonProperty("mention_types", NullValueHandling = NullValueHandling.Ignore)]
        public bool? MentionTypes { get; set; }
        [JsonProperty("sentence_location", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SentenceLocation { get; set; }
        [JsonProperty("model", NullValueHandling = NullValueHandling.Ignore)]
        public string Model { get; set; }
    }
}
