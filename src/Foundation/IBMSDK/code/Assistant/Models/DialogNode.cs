using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Assistant.Models
{
    public class DialogNode
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum NodeTypeEnum
        {
            [EnumMember(Value = "standard")]
            STANDARD,
            [EnumMember(Value = "event_handler")]
            EVENT_HANDLER,
            [EnumMember(Value = "frame")]
            FRAME,
            [EnumMember(Value = "slot")]
            SLOT,
            [EnumMember(Value = "response_condition")]
            RESPONSE_CONDITION
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum EventNameEnum
        {
            [EnumMember(Value = "focus")]
            FOCUS,
            [EnumMember(Value = "input")]
            INPUT,
            [EnumMember(Value = "filled")]
            FILLED,
            [EnumMember(Value = "validate")]
            VALIDATE,
            [EnumMember(Value = "filled_multiple")]
            FILLED_MULTIPLE,
            [EnumMember(Value = "generic")]
            GENERIC,
            [EnumMember(Value = "nomatch")]
            NOMATCH,
            [EnumMember(Value = "nomatch_responses_depleted")]
            NOMATCH_RESPONSES_DEPLETED
        }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public NodeTypeEnum? NodeType { get; set; }
        [JsonProperty("event_name", NullValueHandling = NullValueHandling.Ignore)]
        public EventNameEnum? EventName { get; set; }
        [JsonProperty("dialog_node", NullValueHandling = NullValueHandling.Ignore)]
        public string DialogNodeId { get; set; }
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }
        [JsonProperty("conditions", NullValueHandling = NullValueHandling.Ignore)]
        public string Conditions { get; set; }
        [JsonProperty("parent", NullValueHandling = NullValueHandling.Ignore)]
        public string Parent { get; set; }
        [JsonProperty("previous_sibling", NullValueHandling = NullValueHandling.Ignore)]
        public string PreviousSibling { get; set; }
        [JsonProperty("output", NullValueHandling = NullValueHandling.Ignore)]
        public object Output { get; set; }
        [JsonProperty("context", NullValueHandling = NullValueHandling.Ignore)]
        public object Context { get; set; }
        [JsonProperty("metadata", NullValueHandling = NullValueHandling.Ignore)]
        public object Metadata { get; set; }
        [JsonProperty("next_step", NullValueHandling = NullValueHandling.Ignore)]
        public DialogNodeNextStep NextStep { get; set; }
        [JsonProperty("created", NullValueHandling = NullValueHandling.Ignore)]
        public virtual DateTime Created { get; private set; }
        [JsonProperty("updated", NullValueHandling = NullValueHandling.Ignore)]
        public virtual DateTime Updated { get; private set; }
        [JsonProperty("actions", NullValueHandling = NullValueHandling.Ignore)]
        public List<DialogNodeAction> Actions { get; set; }
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }
        [JsonProperty("variable", NullValueHandling = NullValueHandling.Ignore)]
        public string Variable { get; set; }
    }
}
