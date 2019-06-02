using Newtonsoft.Json;
using System.Collections.Generic;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.SpeechToText.Models
{
    public class Customizations
    {
        [JsonProperty(PropertyName = "customizations")]
        public IList<Customization> Customization { get; set; }
    }
}