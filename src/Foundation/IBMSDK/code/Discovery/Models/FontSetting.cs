using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class FontSetting
    {
        [JsonProperty("level", NullValueHandling = NullValueHandling.Ignore)]
        public long? Level { get; set; }
        [JsonProperty("min_size", NullValueHandling = NullValueHandling.Ignore)]
        public long? MinSize { get; set; }
        [JsonProperty("max_size", NullValueHandling = NullValueHandling.Ignore)]
        public long? MaxSize { get; set; }
        [JsonProperty("bold", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Bold { get; set; }
        [JsonProperty("italic", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Italic { get; set; }
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }
}
