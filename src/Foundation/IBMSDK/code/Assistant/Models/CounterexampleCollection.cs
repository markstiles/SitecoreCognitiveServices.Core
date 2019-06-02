using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Assistant.Models
{
    public class CounterexampleCollection
    {
        [JsonProperty("counterexamples", NullValueHandling = NullValueHandling.Ignore)]
        public List<Counterexample> Counterexamples { get; set; }
        [JsonProperty("pagination", NullValueHandling = NullValueHandling.Ignore)]
        public Pagination Pagination { get; set; }
    }
}
