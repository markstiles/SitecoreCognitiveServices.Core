using Newtonsoft.Json;
using System;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Assistant.Models
{
    public class Intent
    {
        [JsonProperty("intent", NullValueHandling = NullValueHandling.Ignore)]
        public string IntentName { get; set; }
        [JsonProperty("created", NullValueHandling = NullValueHandling.Ignore)]
        public virtual DateTime Created { get; private set; }
        [JsonProperty("updated", NullValueHandling = NullValueHandling.Ignore)]
        public virtual DateTime Updated { get; private set; }
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }
    }
}
