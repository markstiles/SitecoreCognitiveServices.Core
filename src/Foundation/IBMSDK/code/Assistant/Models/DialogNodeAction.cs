using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Assistant.Models
{
    public class DialogNodeAction
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ActionTypeEnum
        {
            [EnumMember(Value = "client")]
            CLIENT,
            [EnumMember(Value = "server")]
            SERVER
        }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public ActionTypeEnum? ActionType { get; set; }
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        [JsonProperty("parameters", NullValueHandling = NullValueHandling.Ignore)]
        public object Parameters { get; set; }
        [JsonProperty("result_variable", NullValueHandling = NullValueHandling.Ignore)]
        public string ResultVariable { get; set; }
        [JsonProperty("credentials", NullValueHandling = NullValueHandling.Ignore)]
        public string Credentials { get; set; }
    }
}
