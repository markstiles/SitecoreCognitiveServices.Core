using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.SpeechToText.Models
{
    public class SpeechRecognitionResult
    {
        [JsonProperty("final")]
        public bool Final { get; set; }
        [JsonProperty("speaker")]
        public int Speaker { get; set; }
        [JsonProperty("alternatives")]
        public List<SpeechRecognitionAlternative> Alternatives { get; set; }
        [JsonProperty("keywords_result")]
        public KeywordResults KeywordResults { get; set; }
        [JsonProperty("word_alternatives")]
        public List<WordAlternativeResults> WordAlternativeResults { get; set; }
    }
}