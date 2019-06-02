using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.LanguageTranslator.Models
{
    public class IdentifiedLanguages
    {
        [JsonProperty("languages", NullValueHandling = NullValueHandling.Ignore)]
        public List<IdentifiedLanguage> Languages { get; set; }
    }
}
