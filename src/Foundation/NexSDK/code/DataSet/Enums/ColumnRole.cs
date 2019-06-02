using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SitecoreCognitiveServices.Foundation.NexSDK.DataSet.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ColumnRole
    {
        [EnumMember(Value = "None")]
        None,

        [EnumMember(Value = "Timestamp")]
        Timestamp,

        [EnumMember(Value = "Target")]
        Target,

        [EnumMember(Value = "Feature")]
        Feature,

        [EnumMember(Value = "Key")] 
        Key
    }
}