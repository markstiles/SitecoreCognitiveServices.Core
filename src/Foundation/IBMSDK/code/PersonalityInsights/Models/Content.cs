using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.PersonalityInsights.Models
{
    public class Content
    {
        [JsonProperty("contentItems", NullValueHandling = NullValueHandling.Ignore)]
        public List<ContentItem> ContentItems { get; set; }
    }
}
