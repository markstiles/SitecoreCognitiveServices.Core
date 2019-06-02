using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SitecoreCognitiveServices.Foundation.NexSDK.Http.Enums;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Http.Models
{
    public class StatusChange
    {
        public DateTimeOffset Date { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Status Status { get; set; }
    }
}
