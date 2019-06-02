using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class ListConfigurationsResponse
    {
        [JsonProperty("configurations", NullValueHandling = NullValueHandling.Ignore)]
        public List<Configuration> Configurations { get; set; }
    }
}
