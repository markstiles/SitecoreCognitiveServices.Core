using Newtonsoft.Json;
using System.Collections.Generic;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.SpeechToText.Models
{
    public partial class WordData
    {
        [JsonProperty(PropertyName = "word")]
        public string Word { get; set; }
        [JsonProperty(PropertyName = "sounds_like")]
        public IList<string> SoundsLike { get; set; }
        [JsonProperty(PropertyName = "display_as")]
        public string DisplayAs { get; set; }
        [JsonProperty(PropertyName = "count")]
        public int Count { get; set; }
        [JsonProperty(PropertyName = "source")]
        public IList<string> Source { get; set; }
        [JsonProperty(PropertyName = "error")]
        public IList<WordError> Error { get; set; }
    }
}
