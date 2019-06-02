using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class DiskUsage
    {
        [JsonProperty("used_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public virtual long? UsedBytes { get; private set; }
        [JsonProperty("maximum_allowed_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public virtual long? MaximumAllowedBytes { get; private set; }
        [JsonProperty("total_bytes", NullValueHandling = NullValueHandling.Ignore)]
        public virtual long? TotalBytes { get; private set; }
        [JsonProperty("used", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Used { get; private set; }
        [JsonProperty("total", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Total { get; private set; }
        [JsonProperty("percent_used", NullValueHandling = NullValueHandling.Ignore)]
        public virtual double? PercentUsed { get; private set; }
    }
}
