using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.SpeechToText.Models
{
    public class WordAlternativeResult
    {
        [JsonProperty("confidence")]
        public double Confidence { get; set; }
        [JsonProperty("word")]
        public string Word { get; set; }
    }
}