using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Assistant.Models
{
    public class EntityExport
    {
        [JsonProperty("entity", NullValueHandling = NullValueHandling.Ignore)]
        public string EntityName { get; set; }
        [JsonProperty("created", NullValueHandling = NullValueHandling.Ignore)]
        public virtual DateTime Created { get; private set; }
        [JsonProperty("updated", NullValueHandling = NullValueHandling.Ignore)]
        public virtual DateTime Updated { get; private set; }
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }
        [JsonProperty("metadata", NullValueHandling = NullValueHandling.Ignore)]
        public object Metadata { get; set; }
        [JsonProperty("fuzzy_match", NullValueHandling = NullValueHandling.Ignore)]
        public bool? FuzzyMatch { get; set; }
        [JsonProperty("values", NullValueHandling = NullValueHandling.Ignore)]
        public List<ValueExport> Values { get; set; }
    }
}
