using Newtonsoft.Json;
using System;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class TrainingStatus
    {
        [JsonProperty("total_examples", NullValueHandling = NullValueHandling.Ignore)]
        public long? TotalExamples { get; set; }
        [JsonProperty("available", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Available { get; set; }
        [JsonProperty("processing", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Processing { get; set; }
        [JsonProperty("minimum_queries_added", NullValueHandling = NullValueHandling.Ignore)]
        public bool? MinimumQueriesAdded { get; set; }
        [JsonProperty("minimum_examples_added", NullValueHandling = NullValueHandling.Ignore)]
        public bool? MinimumExamplesAdded { get; set; }
        [JsonProperty("sufficient_label_diversity", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SufficientLabelDiversity { get; set; }
        [JsonProperty("notices", NullValueHandling = NullValueHandling.Ignore)]
        public long? Notices { get; set; }
        [JsonProperty("successfully_trained", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime SuccessfullyTrained { get; set; }
        [JsonProperty("data_updated", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime DataUpdated { get; set; }
    }
}
