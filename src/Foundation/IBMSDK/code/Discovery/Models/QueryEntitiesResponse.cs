using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class QueryEntitiesResponse
    {
        [JsonProperty("entities", NullValueHandling = NullValueHandling.Ignore)]
        public List<QueryEntitiesEntity> Entities { get; set; }
    }
}
