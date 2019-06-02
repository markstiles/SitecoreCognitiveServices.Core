using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Assistant.Models
{
    public class UpdateWorkspace
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }
        [JsonProperty("language", NullValueHandling = NullValueHandling.Ignore)]
        public string Language { get; set; }
        [JsonProperty("intents", NullValueHandling = NullValueHandling.Ignore)]
        public List<CreateIntent> Intents { get; set; }
        [JsonProperty("entities", NullValueHandling = NullValueHandling.Ignore)]
        public List<CreateEntity> Entities { get; set; }
        [JsonProperty("dialog_nodes", NullValueHandling = NullValueHandling.Ignore)]
        public List<CreateDialogNode> DialogNodes { get; set; }
        [JsonProperty("counterexamples", NullValueHandling = NullValueHandling.Ignore)]
        public List<CreateCounterexample> Counterexamples { get; set; }
        [JsonProperty("metadata", NullValueHandling = NullValueHandling.Ignore)]
        public object Metadata { get; set; }
        [JsonProperty("learning_opt_out", NullValueHandling = NullValueHandling.Ignore)]
        public bool? LearningOptOut { get; set; }
    }
}
