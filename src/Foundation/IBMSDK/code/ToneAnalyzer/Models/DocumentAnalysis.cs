using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.ToneAnalyzer.Models
{
    public class DocumentAnalysis
    {
        [JsonProperty("tones", NullValueHandling = NullValueHandling.Ignore)]
        public List<ToneScore> Tones { get; set; }
        [JsonProperty("tone_categories", NullValueHandling = NullValueHandling.Ignore)]
        public List<ToneCategory> ToneCategories { get; set; }
        [JsonProperty("warning", NullValueHandling = NullValueHandling.Ignore)]
        public string Warning { get; set; }
    }
}
