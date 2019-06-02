using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Assistant.Models
{
    public class IntentCollection
    {
        [JsonProperty("intents", NullValueHandling = NullValueHandling.Ignore)]
        public List<IntentExport> Intents { get; set; }
        [JsonProperty("pagination", NullValueHandling = NullValueHandling.Ignore)]
        public Pagination Pagination { get; set; }
    }
}
