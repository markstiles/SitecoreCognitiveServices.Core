using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class QueryNoticesResponse
    {
        [JsonProperty("matching_results", NullValueHandling = NullValueHandling.Ignore)]
        public long? MatchingResults { get; set; }
        [JsonProperty("results", NullValueHandling = NullValueHandling.Ignore)]
        public List<QueryNoticesResult> Results { get; set; }
        [JsonProperty("aggregations", NullValueHandling = NullValueHandling.Ignore)]
        public List<QueryAggregation> Aggregations { get; set; }
        [JsonProperty("passages", NullValueHandling = NullValueHandling.Ignore)]
        public List<QueryPassages> Passages { get; set; }
        [JsonProperty("duplicates_removed", NullValueHandling = NullValueHandling.Ignore)]
        public long? DuplicatesRemoved { get; set; }
    }
}
