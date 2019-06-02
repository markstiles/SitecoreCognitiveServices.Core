using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class QueryRelations
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum SortEnum
        {
            [EnumMember(Value = "score")]
            SCORE,
            [EnumMember(Value = "frequency")]
            FREQUENCY
        }

        [JsonProperty("sort", NullValueHandling = NullValueHandling.Ignore)]
        public SortEnum? Sort { get; set; }
        [JsonProperty("entities", NullValueHandling = NullValueHandling.Ignore)]
        public List<QueryRelationsEntity> Entities { get; set; }
        [JsonProperty("context", NullValueHandling = NullValueHandling.Ignore)]
        public QueryEntitiesContext Context { get; set; }
        [JsonProperty("filter", NullValueHandling = NullValueHandling.Ignore)]
        public QueryRelationsFilter Filter { get; set; }
        [JsonProperty("count", NullValueHandling = NullValueHandling.Ignore)]
        public long? Count { get; set; }
    }
}
