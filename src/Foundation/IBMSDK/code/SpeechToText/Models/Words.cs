using Newtonsoft.Json;
using System.Collections.Generic;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.SpeechToText.Models
{
    public partial class Words
    {
        [JsonProperty(PropertyName = "words")]
        public IList<Word> WordsProperty { get; set; }
    }
}