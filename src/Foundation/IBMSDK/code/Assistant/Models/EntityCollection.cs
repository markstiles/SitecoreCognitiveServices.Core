using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Assistant.Models
{
    public class EntityCollection
    {
        [JsonProperty("entities", NullValueHandling = NullValueHandling.Ignore)]
        public List<EntityExport> Entities { get; set; }
        [JsonProperty("pagination", NullValueHandling = NullValueHandling.Ignore)]
        public Pagination Pagination { get; set; }
    }
}
