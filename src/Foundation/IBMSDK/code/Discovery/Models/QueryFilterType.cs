using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class QueryFilterType
    {
        [JsonProperty("exclude", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Exclude { get; set; }
        [JsonProperty("include", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Include { get; set; }
    }
}
