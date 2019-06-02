using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.SpeechToText.Models
{
    public class SpeechRecognitionEvent
    {
        [JsonProperty("results")]
        public List<SpeechRecognitionResult> Results { get; set; }
        [JsonProperty("speaker_labels")]
        public List<SpeakerLabelsResult> SpeakerLabels { get; set; }
        [JsonProperty("result_index")]
        public int ResultIndex { get; set; }
        [JsonProperty("warnings")]
        public List<string> Warnings { get; set; }
    }
}