using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.ToneAnalyzer.Models
{
    public class SentenceAnalysis
    {
        [JsonProperty("sentence_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? SentenceId { get; set; }
        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }
        [JsonProperty("tones", NullValueHandling = NullValueHandling.Ignore)]
        public List<ToneScore> Tones { get; set; }
        [JsonProperty("tone_categories", NullValueHandling = NullValueHandling.Ignore)]
        public List<ToneCategory> ToneCategories { get; set; }
        [JsonProperty("input_from", NullValueHandling = NullValueHandling.Ignore)]
        public long? InputFrom { get; set; }
        [JsonProperty("input_to", NullValueHandling = NullValueHandling.Ignore)]
        public long? InputTo { get; set; }
    }
}
