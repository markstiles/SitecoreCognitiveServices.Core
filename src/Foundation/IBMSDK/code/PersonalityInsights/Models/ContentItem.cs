using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.PersonalityInsights.Models
{
    public class ContentItem
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ContenttypeEnum
        {
            [EnumMember(Value = "text/plain")]
            TEXT_PLAIN,
            [EnumMember(Value = "text/html")]
            TEXT_HTML
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum LanguageEnum
        {
            [EnumMember(Value = "ar")]
            AR,
            [EnumMember(Value = "en")]
            EN,
            [EnumMember(Value = "es")]
            ES,
            [EnumMember(Value = "ja")]
            JA,
            [EnumMember(Value = "ko")]
            KO
        }

        [JsonProperty("contenttype", NullValueHandling = NullValueHandling.Ignore)]
        public ContenttypeEnum? Contenttype { get; set; }
        [JsonProperty("language", NullValueHandling = NullValueHandling.Ignore)]
        public LanguageEnum? Language { get; set; }
        [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
        public string Content { get; set; }
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
        [JsonProperty("created", NullValueHandling = NullValueHandling.Ignore)]
        public long? Created { get; set; }
        [JsonProperty("updated", NullValueHandling = NullValueHandling.Ignore)]
        public long? Updated { get; set; }
        [JsonProperty("parentid", NullValueHandling = NullValueHandling.Ignore)]
        public string Parentid { get; set; }
        [JsonProperty("reply", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Reply { get; set; }
        [JsonProperty("forward", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Forward { get; set; }
    }
}
