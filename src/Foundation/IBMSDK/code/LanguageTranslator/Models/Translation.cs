using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.LanguageTranslator.Models
{
    public class Translation
    {
        [JsonProperty("translation", NullValueHandling = NullValueHandling.Ignore)]
        public string TranslationOutput { get; set; }
    }
}
