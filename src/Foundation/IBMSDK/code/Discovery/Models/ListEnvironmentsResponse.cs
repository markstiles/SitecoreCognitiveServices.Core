using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class ListEnvironmentsResponse
    {
        [JsonProperty("environments", NullValueHandling = NullValueHandling.Ignore)]
        public List<Environment> Environments { get; set; }
    }
}
