using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class PdfHeadingDetection
    {
        [JsonProperty("fonts", NullValueHandling = NullValueHandling.Ignore)]
        public List<FontSetting> Fonts { get; set; }
    }
}
