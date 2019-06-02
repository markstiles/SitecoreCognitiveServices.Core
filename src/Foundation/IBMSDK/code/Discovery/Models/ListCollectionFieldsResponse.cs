using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class ListCollectionFieldsResponse
    {
        [JsonProperty("fields", NullValueHandling = NullValueHandling.Ignore)]
        public List<Field> Fields { get; set; }
    }
}
