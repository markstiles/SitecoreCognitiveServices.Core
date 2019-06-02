using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class QueryRelationsArgument
    {
        [JsonProperty("entities", NullValueHandling = NullValueHandling.Ignore)]
        public List<QueryEntitiesEntity> Entities { get; set; }
    }
}
