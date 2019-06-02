using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Assistant.Models
{
    public class ValueExport
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ValueTypeEnum
        {
            [EnumMember(Value = "synonyms")]
            SYNONYMS,
            [EnumMember(Value = "patterns")]
            PATTERNS
        }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public ValueTypeEnum? ValueType { get; set; }
        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public string ValueText { get; set; }
        [JsonProperty("metadata", NullValueHandling = NullValueHandling.Ignore)]
        public object Metadata { get; set; }
        [JsonProperty("created", NullValueHandling = NullValueHandling.Ignore)]
        public virtual DateTime Created { get; private set; }
        [JsonProperty("updated", NullValueHandling = NullValueHandling.Ignore)]
        public virtual DateTime Updated { get; private set; }
        [JsonProperty("synonyms", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Synonyms { get; set; }
        [JsonProperty("patterns", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Patterns { get; set; }
    }
}
