using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class QueryRelationsRelationship
    {
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }
        [JsonProperty("frequency", NullValueHandling = NullValueHandling.Ignore)]
        public long? Frequency { get; set; }
        [JsonProperty("arguments", NullValueHandling = NullValueHandling.Ignore)]
        public List<QueryRelationsArgument> Arguments { get; set; }
    }
}
