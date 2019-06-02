using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.SpeechToText.Models
{
    public class SpeakerLabelsResult
    {
        [JsonProperty("from")]
        public double From { get; set; }
        [JsonProperty("to")]
        public double To { get; set; }
        [JsonProperty("speaker")]
        public int Speaker { get; set; }
        [JsonProperty("confidence")]
        public double Confidence { get; set; }
        [JsonProperty("final")]
        public bool Final { get; set; }
    }
}