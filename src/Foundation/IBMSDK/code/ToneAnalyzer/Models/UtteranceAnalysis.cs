using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.ToneAnalyzer.Models
{
    public class UtteranceAnalysis
    {
        [JsonProperty("utterance_id", NullValueHandling = NullValueHandling.Ignore)]
        public string UtteranceId { get; set; }
        [JsonProperty("utterance_text", NullValueHandling = NullValueHandling.Ignore)]
        public string UtteranceText { get; set; }
        [JsonProperty("tones", NullValueHandling = NullValueHandling.Ignore)]
        public List<ToneChatScore> Tones { get; set; }
        [JsonProperty("error", NullValueHandling = NullValueHandling.Ignore)]
        public string Error { get; set; }
    }
}
