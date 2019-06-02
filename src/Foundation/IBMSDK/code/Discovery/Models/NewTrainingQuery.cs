using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class NewTrainingQuery
    {
        [JsonProperty("natural_language_query", NullValueHandling = NullValueHandling.Ignore)]
        public string NaturalLanguageQuery { get; set; }
        [JsonProperty("filter", NullValueHandling = NullValueHandling.Ignore)]
        public string Filter { get; set; }
        [JsonProperty("examples", NullValueHandling = NullValueHandling.Ignore)]
        public List<TrainingExample> Examples { get; set; }
    }
}
