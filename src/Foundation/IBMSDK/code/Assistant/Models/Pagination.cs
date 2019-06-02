using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Assistant.Models
{
    public class Pagination
    {
        [JsonProperty("refresh_url", NullValueHandling = NullValueHandling.Ignore)]
        public string RefreshUrl { get; set; }
        [JsonProperty("next_url", NullValueHandling = NullValueHandling.Ignore)]
        public string NextUrl { get; set; }
        [JsonProperty("total", NullValueHandling = NullValueHandling.Ignore)]
        public long? Total { get; set; }
        [JsonProperty("matched", NullValueHandling = NullValueHandling.Ignore)]
        public long? Matched { get; set; }
    }
}
