using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class IndexCapacity
    {
        [JsonProperty("documents", NullValueHandling = NullValueHandling.Ignore)]
        public EnvironmentDocuments Documents { get; set; }
        [JsonProperty("disk_usage", NullValueHandling = NullValueHandling.Ignore)]
        public DiskUsage DiskUsage { get; set; }
        [JsonProperty("collections", NullValueHandling = NullValueHandling.Ignore)]
        public CollectionUsage Collections { get; set; }
        [JsonProperty("memory_usage", NullValueHandling = NullValueHandling.Ignore)]
        public MemoryUsage MemoryUsage { get; set; }
    }
}
