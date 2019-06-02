using Newtonsoft.Json;
using System;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Assistant.Models
{
    public class Synonym
    {
        [JsonProperty("synonym", NullValueHandling = NullValueHandling.Ignore)]
        public string SynonymText { get; set; }
        [JsonProperty("created", NullValueHandling = NullValueHandling.Ignore)]
        public virtual DateTime Created { get; private set; }
        [JsonProperty("updated", NullValueHandling = NullValueHandling.Ignore)]
        public virtual DateTime Updated { get; private set; }
    }
}
