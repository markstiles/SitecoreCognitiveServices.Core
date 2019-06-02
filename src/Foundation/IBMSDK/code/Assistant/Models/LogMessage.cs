using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Assistant.Models
{
    public class LogMessage
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum LevelEnum
        {
            [EnumMember(Value = "info")]
            INFO,
            [EnumMember(Value = "error")]
            ERROR,
            [EnumMember(Value = "warn")]
            WARN
        }

        [JsonProperty("level", NullValueHandling = NullValueHandling.Ignore)]
        public LevelEnum? Level { get; set; }
        [JsonProperty("msg", NullValueHandling = NullValueHandling.Ignore)]
        public dynamic Msg { get; set; }
    }
}
