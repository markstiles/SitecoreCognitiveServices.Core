using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.SpeechToText.Models
{
    public class Corpus
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "total_words")]
        public int TotalWords { get; set; }
        [JsonProperty(PropertyName = "out_of_vocabulary_words")]
        public int OutOfVocabularyWords { get; set; }
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }
    }
}
