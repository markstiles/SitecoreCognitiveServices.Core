using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.ToneAnalyzer.Models
{
    public class UtteranceAnalyses
    {
        [JsonProperty("utterances_tone", NullValueHandling = NullValueHandling.Ignore)]
        public List<UtteranceAnalysis> UtterancesTone { get; set; }
        [JsonProperty("warning", NullValueHandling = NullValueHandling.Ignore)]
        public string Warning { get; set; }
    }
}
