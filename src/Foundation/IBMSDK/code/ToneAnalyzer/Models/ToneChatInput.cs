using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.ToneAnalyzer.Models
{
    public class ToneChatInput
    {
        [JsonProperty("utterances", NullValueHandling = NullValueHandling.Ignore)]
        public List<Utterance> Utterances { get; set; }
    }
}
