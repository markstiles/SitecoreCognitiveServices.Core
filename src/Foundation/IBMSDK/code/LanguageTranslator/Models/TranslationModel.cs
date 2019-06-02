using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.LanguageTranslator.Models
{
    public class TranslationModel
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "uploading")]
            UPLOADING,
            [EnumMember(Value = "uploaded")]
            UPLOADED,
            [EnumMember(Value = "dispatching")]
            DISPATCHING,
            [EnumMember(Value = "queued")]
            QUEUED,
            [EnumMember(Value = "training")]
            TRAINING,
            [EnumMember(Value = "trained")]
            TRAINED,
            [EnumMember(Value = "publishing")]
            PUBLISHING,
            [EnumMember(Value = "available")]
            AVAILABLE,
            [EnumMember(Value = "deleted")]
            DELETED,
            [EnumMember(Value = "error")]
            ERROR
        }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public StatusEnum? Status { get; set; }
        [JsonProperty("model_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ModelId { get; set; }
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
        public string Source { get; set; }
        [JsonProperty("target", NullValueHandling = NullValueHandling.Ignore)]
        public string Target { get; set; }
        [JsonProperty("base_model_id", NullValueHandling = NullValueHandling.Ignore)]
        public string BaseModelId { get; set; }
        [JsonProperty("domain", NullValueHandling = NullValueHandling.Ignore)]
        public string Domain { get; set; }
        [JsonProperty("customizable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Customizable { get; set; }
        [JsonProperty("default_model", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DefaultModel { get; set; }
        [JsonProperty("owner", NullValueHandling = NullValueHandling.Ignore)]
        public string Owner { get; set; }
    }
}
