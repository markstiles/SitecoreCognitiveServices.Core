using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class QueryResult
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public dynamic Id { get; set; }
        [JsonProperty("score", NullValueHandling = NullValueHandling.Ignore)]
        public dynamic Score { get; set; }
        [JsonProperty("metadata", NullValueHandling = NullValueHandling.Ignore)]
        public dynamic Metadata { get; set; }
        [JsonProperty("collection_id", NullValueHandling = NullValueHandling.Ignore)]
        public dynamic CollectionId { get; set; }
        [JsonProperty("result_metadata", NullValueHandling = NullValueHandling.Ignore)]
        public dynamic ResultMetadata { get; set; }
    }
}
