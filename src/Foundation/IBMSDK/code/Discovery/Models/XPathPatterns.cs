using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class XPathPatterns
    {
        [JsonProperty("xpaths", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Xpaths { get; set; }
    }
}
