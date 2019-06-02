using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Assistant.Models
{
    public class LogPagination
    {
        [JsonProperty("next_url", NullValueHandling = NullValueHandling.Ignore)]
        public string NextUrl { get; set; }
        [JsonProperty("matched", NullValueHandling = NullValueHandling.Ignore)]
        public long? Matched { get; set; }
    }
}
