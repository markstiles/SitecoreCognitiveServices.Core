using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.SpeechToText.Models
{
    public class SpeechRecognitionAlternative
    {
        [JsonProperty("transcript")]
        public string Transcript { get; set; }
        [JsonProperty("confidence")]
        public double Confidence { get; set; }
        [JsonProperty("timestamps")]
        public string[][] Timestamps { get; set; }
        [JsonProperty("word_confidence")]
        public List<string> WordConfidence { get; set; }
    }
}