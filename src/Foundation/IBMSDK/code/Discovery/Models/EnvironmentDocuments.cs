using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class EnvironmentDocuments
    {
        [JsonProperty("indexed", NullValueHandling = NullValueHandling.Ignore)]
        public virtual long? Indexed { get; private set; }
        [JsonProperty("maximum_allowed", NullValueHandling = NullValueHandling.Ignore)]
        public virtual long? MaximumAllowed { get; private set; }
    }
}
