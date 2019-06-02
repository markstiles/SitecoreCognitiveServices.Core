using Newtonsoft.Json;
using System.Collections.Generic;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.TextToSpeech.Models
{
    public class CustomWordTranslation
    {
        [JsonProperty("word")]
        public string Word { get; set; }
        [JsonProperty("translation")]
        public string Translation { get; set; }
    }

    internal class CustomWordTranslations
    {
        [JsonProperty("words")]
        public List<CustomWordTranslation> Words { get; set; }
    }
}
