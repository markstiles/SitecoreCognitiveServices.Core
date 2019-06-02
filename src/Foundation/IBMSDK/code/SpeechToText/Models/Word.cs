using Newtonsoft.Json;
using System.Collections.Generic;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.SpeechToText.Models
{
    public partial class Word
    {
        [JsonProperty(PropertyName = "word")]
        public string WordProperty { get; set; }
        [JsonProperty(PropertyName = "sounds_like")]
        public IList<string> SoundsLike { get; set; }
        [JsonProperty(PropertyName = "display_as")]
        public string DisplayAs { get; set; }
    }
}
