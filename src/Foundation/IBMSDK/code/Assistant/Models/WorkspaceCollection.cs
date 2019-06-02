using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Assistant.Models
{
    public class WorkspaceCollection
    {
        [JsonProperty("workspaces", NullValueHandling = NullValueHandling.Ignore)]
        public List<Workspace> Workspaces { get; set; }
        [JsonProperty("pagination", NullValueHandling = NullValueHandling.Ignore)]
        public Pagination Pagination { get; set; }
    }
}
