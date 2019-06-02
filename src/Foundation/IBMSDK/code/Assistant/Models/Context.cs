using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Assistant.Models
{
    public class Context
    {
        [JsonProperty("conversation_id", NullValueHandling = NullValueHandling.Ignore)]
        public dynamic ConversationId { get; set; }
        [JsonProperty("system", NullValueHandling = NullValueHandling.Ignore)]
        public dynamic System { get; set; }
    }
}
