using Newtonsoft.Json;
using System;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Assistant.Models
{
    public class Example
    {
        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string ExampleText { get; set; }
        [JsonProperty("created", NullValueHandling = NullValueHandling.Ignore)]
        public virtual DateTime Created { get; private set; }
        [JsonProperty("updated", NullValueHandling = NullValueHandling.Ignore)]
        public virtual DateTime Updated { get; private set; }
    }
}
