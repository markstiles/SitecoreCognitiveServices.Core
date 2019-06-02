using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Assistant.Models
{
    public class OutputData
    {
        [JsonProperty("log_messages", NullValueHandling = NullValueHandling.Ignore)]
        public dynamic LogMessages { get; set; }
        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public dynamic Text { get; set; }
        [JsonProperty("nodes_visited", NullValueHandling = NullValueHandling.Ignore)]
        public dynamic NodesVisited { get; set; }
    }
}
