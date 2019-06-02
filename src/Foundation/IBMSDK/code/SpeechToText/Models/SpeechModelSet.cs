using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.SpeechToText.Models
{
    public class SpeechModelSet
    {
        [JsonProperty("models")]
        public List<SpeechModel> Models { get; set; }
    }
}