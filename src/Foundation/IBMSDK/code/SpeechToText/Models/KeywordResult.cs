using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.SpeechToText.Models
{
    public class KeywordResult
    {
        [JsonProperty("normalized_text")]
        public string NormalizedText { get; set; }
        [JsonProperty("start_time")]
        public double StartTime { get; set; }
        [JsonProperty("end_time")]
        public double Endtime { get; set; }
        [JsonProperty("confidence")]
        public double Confidence { get; set; }
    }
}