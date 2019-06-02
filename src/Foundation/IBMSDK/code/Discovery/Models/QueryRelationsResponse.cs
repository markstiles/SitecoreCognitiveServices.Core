using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class QueryRelationsResponse
    {
        [JsonProperty("relations", NullValueHandling = NullValueHandling.Ignore)]
        public List<QueryRelationsRelationship> Relations { get; set; }
    }
}
