using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class Notice
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum SeverityEnum
        {
            [EnumMember(Value = "warning")]
            WARNING,
            [EnumMember(Value = "error")]
            ERROR
        }

        [JsonProperty("severity", NullValueHandling = NullValueHandling.Ignore)]
        public SeverityEnum? Severity { get; set; }
        [JsonProperty("notice_id", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string NoticeId { get; private set; }
        [JsonProperty("created", NullValueHandling = NullValueHandling.Ignore)]
        public virtual DateTime Created { get; private set; }
        [JsonProperty("document_id", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string DocumentId { get; private set; }
        [JsonProperty("query_id", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string QueryId { get; private set; }
        [JsonProperty("step", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Step { get; private set; }
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Description { get; private set; }
    }
}
