using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.LanguageTranslator.Models
{
    public class TranslationResult
    {
        [JsonProperty("word_count", NullValueHandling = NullValueHandling.Ignore)]
        public long? WordCount { get; set; }
        [JsonProperty("character_count", NullValueHandling = NullValueHandling.Ignore)]
        public long? CharacterCount { get; set; }
        [JsonProperty("translations", NullValueHandling = NullValueHandling.Ignore)]
        public List<Translation> Translations { get; set; }
    }
}
