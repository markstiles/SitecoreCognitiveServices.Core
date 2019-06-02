using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.SpeechToText.Models
{
    public class Corpora
    {
        [JsonProperty(PropertyName = "corpora")]
        public IList<Corpus> CorporaProperty { get; set; }
    }
}