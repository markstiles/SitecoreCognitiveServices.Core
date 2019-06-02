using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Assistant.Models
{
    public class DialogNodeNextStep
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum BehaviorEnum
        {
            [EnumMember(Value = "jump_to")]
            JUMP_TO
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum SelectorEnum
        {
            [EnumMember(Value = "condition")]
            CONDITION,
            [EnumMember(Value = "client")]
            CLIENT,
            [EnumMember(Value = "user_input")]
            USER_INPUT,
            [EnumMember(Value = "body")]
            BODY
        }

        [JsonProperty("behavior", NullValueHandling = NullValueHandling.Ignore)]
        public BehaviorEnum? Behavior { get; set; }
        [JsonProperty("selector", NullValueHandling = NullValueHandling.Ignore)]
        public SelectorEnum? Selector { get; set; }
        [JsonProperty("dialog_node", NullValueHandling = NullValueHandling.Ignore)]
        public string DialogNode { get; set; }
    }
}
