using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.PersonalityInsights.Models
{
    public class Warning
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum WarningIdEnum
        {
            [EnumMember(Value = "WORD_COUNT_MESSAGE")]
            WORD_COUNT_MESSAGE,
            [EnumMember(Value = "JSON_AS_TEXT")]
            JSON_AS_TEXT,
            [EnumMember(Value = "CONTENT_TRUNCATED")]
            CONTENT_TRUNCATED,
            [EnumMember(Value = "PARTIAL_TEXT_USED")]
            PARTIAL_TEXT_USED
        }

        [JsonProperty("warning_id", NullValueHandling = NullValueHandling.Ignore)]
        public WarningIdEnum? WarningId { get; set; }
        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }
    }
}
