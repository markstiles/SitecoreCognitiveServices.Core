using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class QueryRelationsFilter
    {
        [JsonProperty("relation_types", NullValueHandling = NullValueHandling.Ignore)]
        public QueryFilterType RelationTypes { get; set; }
        [JsonProperty("entity_types", NullValueHandling = NullValueHandling.Ignore)]
        public QueryFilterType EntityTypes { get; set; }
        [JsonProperty("document_ids", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> DocumentIds { get; set; }
    }
}
