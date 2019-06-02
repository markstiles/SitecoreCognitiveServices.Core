using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class PdfSettings
    {
        [JsonProperty("heading", NullValueHandling = NullValueHandling.Ignore)]
        public PdfHeadingDetection Heading { get; set; }
    }
}
