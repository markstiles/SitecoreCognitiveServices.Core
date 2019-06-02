using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.PersonalityInsights.Models
{
    public class Trait
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum CategoryEnum
        {
            [EnumMember(Value = "personality")]
            PERSONALITY,
            [EnumMember(Value = "needs")]
            NEEDS,
            [EnumMember(Value = "values")]
            VALUES
        }

        [JsonProperty("category", NullValueHandling = NullValueHandling.Ignore)]
        public CategoryEnum? Category { get; set; }
        [JsonProperty("trait_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TraitId { get; set; }
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        [JsonProperty("percentile", NullValueHandling = NullValueHandling.Ignore)]
        public double? Percentile { get; set; }
        [JsonProperty("raw_score", NullValueHandling = NullValueHandling.Ignore)]
        public double? RawScore { get; set; }
        [JsonProperty("significant", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Significant { get; set; }
        [JsonProperty("children", NullValueHandling = NullValueHandling.Ignore)]
        public List<Trait> Children { get; set; }
    }
}
