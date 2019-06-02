using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class DocumentStatus
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "available")]
            AVAILABLE,
            [EnumMember(Value = "available with notices")]
            AVAILABLE_WITH_NOTICES,
            [EnumMember(Value = "failed")]
            FAILED,
            [EnumMember(Value = "processing")]
            PROCESSING
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum FileTypeEnum
        {
            [EnumMember(Value = "pdf")]
            PDF,
            [EnumMember(Value = "html")]
            HTML,
            [EnumMember(Value = "word")]
            WORD,
            [EnumMember(Value = "json")]
            JSON
        }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public StatusEnum? Status { get; set; }
        [JsonProperty("file_type", NullValueHandling = NullValueHandling.Ignore)]
        public FileTypeEnum? FileType { get; set; }
        [JsonProperty("document_id", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string DocumentId { get; private set; }
        [JsonProperty("configuration_id", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string ConfigurationId { get; private set; }
        [JsonProperty("created", NullValueHandling = NullValueHandling.Ignore)]
        public virtual DateTime Created { get; private set; }
        [JsonProperty("updated", NullValueHandling = NullValueHandling.Ignore)]
        public virtual DateTime Updated { get; private set; }
        [JsonProperty("status_description", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string StatusDescription { get; private set; }
        [JsonProperty("filename", NullValueHandling = NullValueHandling.Ignore)]
        public string Filename { get; set; }
        [JsonProperty("sha1", NullValueHandling = NullValueHandling.Ignore)]
        public string Sha1 { get; set; }
        [JsonProperty("notices", NullValueHandling = NullValueHandling.Ignore)]
        public List<Notice> Notices { get; set; }
    }
}
