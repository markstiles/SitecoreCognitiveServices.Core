using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class NormalizationOperation
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum OperationEnum
        {
            [EnumMember(Value = "copy")]
            COPY,
            [EnumMember(Value = "move")]
            MOVE,
            [EnumMember(Value = "merge")]
            MERGE,
            [EnumMember(Value = "remove")]
            REMOVE,
            [EnumMember(Value = "remove_nulls")]
            REMOVE_NULLS
        }

        [JsonProperty("operation", NullValueHandling = NullValueHandling.Ignore)]
        public OperationEnum? Operation { get; set; }
        [JsonProperty("source_field", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceField { get; set; }
        [JsonProperty("destination_field", NullValueHandling = NullValueHandling.Ignore)]
        public string DestinationField { get; set; }
    }
}
