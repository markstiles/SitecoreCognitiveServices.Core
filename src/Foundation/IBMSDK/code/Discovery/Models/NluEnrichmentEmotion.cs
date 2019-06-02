using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class NluEnrichmentEmotion
    {
        [JsonProperty("document", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Document { get; set; }
        [JsonProperty("targets", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Targets { get; set; }
    }
}
