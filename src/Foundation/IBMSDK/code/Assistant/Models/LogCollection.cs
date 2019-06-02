using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Assistant.Models
{
    public class LogCollection
    {
        [JsonProperty("logs", NullValueHandling = NullValueHandling.Ignore)]
        public List<LogExport> Logs { get; set; }
        [JsonProperty("pagination", NullValueHandling = NullValueHandling.Ignore)]
        public LogPagination Pagination { get; set; }
    }
}
