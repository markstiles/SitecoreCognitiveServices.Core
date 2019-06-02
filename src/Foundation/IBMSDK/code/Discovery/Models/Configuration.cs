using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class Configuration
    {
        [JsonProperty("configuration_id", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string ConfigurationId { get; private set; }
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        [JsonProperty("created", NullValueHandling = NullValueHandling.Ignore)]
        public virtual DateTime Created { get; private set; }
        [JsonProperty("updated", NullValueHandling = NullValueHandling.Ignore)]
        public virtual DateTime Updated { get; private set; }
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }
        [JsonProperty("conversions", NullValueHandling = NullValueHandling.Ignore)]
        public Conversions Conversions { get; set; }
        [JsonProperty("enrichments", NullValueHandling = NullValueHandling.Ignore)]
        public List<Enrichment> Enrichments { get; set; }
        [JsonProperty("normalizations", NullValueHandling = NullValueHandling.Ignore)]
        public List<NormalizationOperation> Normalizations { get; set; }
    }
}
