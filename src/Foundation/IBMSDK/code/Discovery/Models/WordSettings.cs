using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class WordSettings
    {
        [JsonProperty("heading", NullValueHandling = NullValueHandling.Ignore)]
        public WordHeadingDetection Heading { get; set; }
    }
}
