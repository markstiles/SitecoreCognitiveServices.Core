using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.SpeechToText.Models
{
    public class CustomizationID
    {
        [JsonProperty("customization_id")]
        public string CustomizationId { get; set; }
    }
}