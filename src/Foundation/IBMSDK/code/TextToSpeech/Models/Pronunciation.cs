using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.TextToSpeech.Models
{
    public class Pronunciation
    {
        [JsonProperty("pronunciation")]
        public string Value { get; set; }
    }
}