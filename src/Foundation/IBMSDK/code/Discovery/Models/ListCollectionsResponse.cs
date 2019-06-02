using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class ListCollectionsResponse
    {
        [JsonProperty("collections", NullValueHandling = NullValueHandling.Ignore)]
        public List<Collection> Collections { get; set; }
    }
}
