using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.SpeechToText.Models
{
    public partial class WordError
    {
        [JsonProperty("element")]
        public string Element { get; set; }
    }
}
