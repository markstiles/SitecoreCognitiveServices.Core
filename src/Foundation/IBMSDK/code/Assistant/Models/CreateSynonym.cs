using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Assistant.Models
{
    public class CreateSynonym
    {
        [JsonProperty("synonym", NullValueHandling = NullValueHandling.Ignore)]
        public string Synonym { get; set; }
    }
}
