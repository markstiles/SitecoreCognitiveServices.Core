using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.SpeechToText.Models
{
    public class KeywordResults
    {
        [JsonProperty("keyword")]
        public List<KeywordResult> Keyword { get; set; }
    }
}