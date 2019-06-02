using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class DocumentSnapshot
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StepEnum
        {
            [EnumMember(Value = "html_input")]
            HTML_INPUT,
            [EnumMember(Value = "html_output")]
            HTML_OUTPUT,
            [EnumMember(Value = "json_output")]
            JSON_OUTPUT,
            [EnumMember(Value = "json_normalizations_output")]
            JSON_NORMALIZATIONS_OUTPUT,
            [EnumMember(Value = "enrichments_output")]
            ENRICHMENTS_OUTPUT,
            [EnumMember(Value = "normalizations_output")]
            NORMALIZATIONS_OUTPUT
        }

        [JsonProperty("step", NullValueHandling = NullValueHandling.Ignore)]
        public StepEnum? Step { get; set; }
        [JsonProperty("snapshot", NullValueHandling = NullValueHandling.Ignore)]
        public object Snapshot { get; set; }
    }
}
