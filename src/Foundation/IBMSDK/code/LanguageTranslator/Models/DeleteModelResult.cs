using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.LanguageTranslator.Models
{
    public class DeleteModelResult
    {
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }
    }
}
