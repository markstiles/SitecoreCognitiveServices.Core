using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class CollectionUsage
    {
        [JsonProperty("available", NullValueHandling = NullValueHandling.Ignore)]
        public virtual long? Available { get; private set; }
        [JsonProperty("maximum_allowed", NullValueHandling = NullValueHandling.Ignore)]
        public virtual long? MaximumAllowed { get; private set; }
    }
}
