using Newtonsoft.Json;
using System.Collections.Generic;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.SpeechToText.Models
{
    public partial class WordsList
    {
        [JsonProperty(PropertyName = "words")]
        public IList<WordData> Words { get; set; }
    }
}