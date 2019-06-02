using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class TrainingExampleList
    {
        [JsonProperty("examples", NullValueHandling = NullValueHandling.Ignore)]
        public List<TrainingExample> Examples { get; set; }
    }
}
