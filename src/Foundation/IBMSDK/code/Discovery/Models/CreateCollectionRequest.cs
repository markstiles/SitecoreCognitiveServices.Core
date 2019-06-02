using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class CreateCollectionRequest
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum LanguageEnum
        {
            [EnumMember(Value = "en")]
            EN,
            [EnumMember(Value = "es")]
            ES,
            [EnumMember(Value = "de")]
            DE,
            [EnumMember(Value = "ar")]
            AR,
            [EnumMember(Value = "fr")]
            FR,
            [EnumMember(Value = "it")]
            IT,
            [EnumMember(Value = "ja")]
            JA,
            [EnumMember(Value = "ko")]
            KO,
            [EnumMember(Value = "pt-br")]
            PT_BR
        }

        [JsonProperty("language", NullValueHandling = NullValueHandling.Ignore)]
        public LanguageEnum? Language { get; set; }
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }
        [JsonProperty("configuration_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ConfigurationId { get; set; }
    }
}
