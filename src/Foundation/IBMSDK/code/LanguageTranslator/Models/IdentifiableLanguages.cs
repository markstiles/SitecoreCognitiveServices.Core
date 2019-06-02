using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.LanguageTranslator.Models
{
    public class IdentifiableLanguages
    {
        [JsonProperty("languages", NullValueHandling = NullValueHandling.Ignore)]
        public List<IdentifiableLanguage> Languages { get; set; }
    }

}
