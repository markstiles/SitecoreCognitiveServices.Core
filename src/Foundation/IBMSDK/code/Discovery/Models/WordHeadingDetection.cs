using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class WordHeadingDetection
    {
        [JsonProperty("fonts", NullValueHandling = NullValueHandling.Ignore)]
        public List<FontSetting> Fonts { get; set; }
        [JsonProperty("styles", NullValueHandling = NullValueHandling.Ignore)]
        public List<WordStyle> Styles { get; set; }
    }
}
