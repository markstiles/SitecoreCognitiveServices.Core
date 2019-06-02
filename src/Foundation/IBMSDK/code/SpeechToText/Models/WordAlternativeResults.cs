using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.SpeechToText.Models
{
    public class WordAlternativeResults
    {
        [JsonProperty("start_time")]
        public double StartTime { get; set; }
        [JsonProperty("end_time")]
        public double Endtime { get; set; }
        [JsonProperty("alternatives")]
        public List<WordAlternativeResult> Alternatives { get; set; }
    }
}