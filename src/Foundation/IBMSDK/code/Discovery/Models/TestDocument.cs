using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class TestDocument
    {
        [JsonProperty("configuration_id", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string ConfigurationId { get; private set; }
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Status { get; private set; }
        [JsonProperty("enriched_field_units", NullValueHandling = NullValueHandling.Ignore)]
        public virtual long? EnrichedFieldUnits { get; private set; }
        [JsonProperty("original_media_type", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string OriginalMediaType { get; private set; }
        [JsonProperty("snapshots", NullValueHandling = NullValueHandling.Ignore)]
        public List<DocumentSnapshot> Snapshots { get; set; }
        [JsonProperty("notices", NullValueHandling = NullValueHandling.Ignore)]
        public List<Notice> Notices { get; set; }
    }
}
