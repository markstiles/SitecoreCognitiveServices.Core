using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class Collection
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "active")]
            ACTIVE,
            [EnumMember(Value = "pending")]
            PENDING,
            [EnumMember(Value = "maintenance")]
            MAINTENANCE
        }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public StatusEnum? Status { get; set; }
        [JsonProperty("collection_id", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string CollectionId { get; private set; }
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }
        [JsonProperty("created", NullValueHandling = NullValueHandling.Ignore)]
        public virtual DateTime Created { get; private set; }
        [JsonProperty("updated", NullValueHandling = NullValueHandling.Ignore)]
        public virtual DateTime Updated { get; private set; }
        [JsonProperty("configuration_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ConfigurationId { get; set; }
        [JsonProperty("language", NullValueHandling = NullValueHandling.Ignore)]
        public string Language { get; set; }
        [JsonProperty("document_counts", NullValueHandling = NullValueHandling.Ignore)]
        public DocumentCounts DocumentCounts { get; set; }
        [JsonProperty("disk_usage", NullValueHandling = NullValueHandling.Ignore)]
        public CollectionDiskUsage DiskUsage { get; set; }
        [JsonProperty("training_status", NullValueHandling = NullValueHandling.Ignore)]
        public TrainingStatus TrainingStatus { get; set; }
    }
}
