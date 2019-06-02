using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.ToneAnalyzer.Models
{
    public class ToneAnalysis
    {
        [JsonProperty("document_tone", NullValueHandling = NullValueHandling.Ignore)]
        public DocumentAnalysis DocumentTone { get; set; }
        [JsonProperty("sentences_tone", NullValueHandling = NullValueHandling.Ignore)]
        public List<SentenceAnalysis> SentencesTone { get; set; }
    }
}
