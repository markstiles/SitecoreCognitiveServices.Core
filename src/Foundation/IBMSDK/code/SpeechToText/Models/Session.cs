using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.SpeechToText.Models
{
    public class Session
    {
        [JsonProperty("session_id")]
        public string SessionId { get; set; }
        [JsonProperty("new_session_uri")]
        public string NewSessionUri { get; set; }
        [JsonProperty("recognize")]
        public string Recognize { get; set; }
        [JsonProperty("observe_result")]
        public string ObserveResult { get; set; }
        [JsonProperty("recognizeWS")]
        public string RecognizeWS { get; set; }
    }
}