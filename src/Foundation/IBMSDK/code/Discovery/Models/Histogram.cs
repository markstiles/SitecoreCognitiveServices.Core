using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class Histogram
    {
        [JsonProperty("interval", NullValueHandling = NullValueHandling.Ignore)]
        public virtual long? Interval { get; private set; }
    }
}
