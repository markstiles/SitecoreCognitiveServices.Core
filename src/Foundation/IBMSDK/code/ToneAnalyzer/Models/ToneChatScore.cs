using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.ToneAnalyzer.Models
{
    public class ToneChatScore
    {
        [JsonProperty("score", NullValueHandling = NullValueHandling.Ignore)]
        public double? Score { get; set; }
        [JsonProperty("tone_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ToneId { get; set; }
        [JsonProperty("tone_name", NullValueHandling = NullValueHandling.Ignore)]
        public string ToneName { get; set; }
    }
}
