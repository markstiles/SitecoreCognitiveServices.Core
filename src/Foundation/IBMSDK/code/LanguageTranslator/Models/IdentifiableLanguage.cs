using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.LanguageTranslator.Models
{
    public class IdentifiableLanguage
    {
        [JsonProperty("language", NullValueHandling = NullValueHandling.Ignore)]
        public string Language { get; set; }
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }
}
