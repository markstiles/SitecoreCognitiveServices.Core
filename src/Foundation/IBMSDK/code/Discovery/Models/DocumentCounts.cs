using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class DocumentCounts
    {
        [JsonProperty("available", NullValueHandling = NullValueHandling.Ignore)]
        public virtual long? Available { get; private set; }
        [JsonProperty("processing", NullValueHandling = NullValueHandling.Ignore)]
        public virtual long? Processing { get; private set; }
        [JsonProperty("failed", NullValueHandling = NullValueHandling.Ignore)]
        public virtual long? Failed { get; private set; }
    }
}
