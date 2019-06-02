using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.SpeechToText.Models
{
    public class RecognizeStatus
    {
        [JsonProperty("session")]
        public SessionStatus Session { get; set; }
    }
}