using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.TextToSpeech.Models
{
    public class WordPronunciation
    {
        [JsonProperty("pronunciation")]
        public string Pronunciation { get; set; }
    }
}