using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.LanguageTranslator.Models
{
    public class TranslationModels
    {
        [JsonProperty("models", NullValueHandling = NullValueHandling.Ignore)]
        public List<TranslationModel> Models { get; set; }
    }
}
