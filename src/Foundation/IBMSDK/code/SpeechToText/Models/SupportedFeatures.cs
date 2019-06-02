using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.SpeechToText.Models
{
    public class SupportedFeatures
    {
        [JsonProperty("custom_language_model")]
        public bool CustomLanguageModel { get; set; }
        [JsonProperty("speaker_labels")]
        public bool SpeakerLabels { get; set; }
    }
}