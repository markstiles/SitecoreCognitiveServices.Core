using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class Field
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum FieldTypeEnum
        {
            [EnumMember(Value = "nested")]
            NESTED,
            [EnumMember(Value = "string")]
            STRING,
            [EnumMember(Value = "date")]
            DATE,
            [EnumMember(Value = "long")]
            LONG,
            [EnumMember(Value = "integer")]
            INTEGER,
            [EnumMember(Value = "short")]
            SHORT,
            [EnumMember(Value = "byte")]
            BYTE,
            [EnumMember(Value = "double")]
            DOUBLE,
            [EnumMember(Value = "float")]
            FLOAT,
            [EnumMember(Value = "boolean")]
            BOOLEAN,
            [EnumMember(Value = "binary")]
            BINARY
        }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public FieldTypeEnum? FieldType { get; set; }
        [JsonProperty("field", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string FieldName { get; private set; }
    }
}
