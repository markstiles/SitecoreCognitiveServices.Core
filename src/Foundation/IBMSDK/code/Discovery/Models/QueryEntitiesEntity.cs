using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class QueryEntitiesEntity
    {
        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }
    }
}
