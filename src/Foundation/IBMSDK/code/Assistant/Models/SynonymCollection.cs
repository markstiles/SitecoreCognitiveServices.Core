using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Assistant.Models
{
    public class SynonymCollection
    {
        [JsonProperty("synonyms", NullValueHandling = NullValueHandling.Ignore)]
        public List<Synonym> Synonyms { get; set; }
        [JsonProperty("pagination", NullValueHandling = NullValueHandling.Ignore)]
        public Pagination Pagination { get; set; }
    }
}
