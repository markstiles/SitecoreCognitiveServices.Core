namespace SitecoreCognitiveServices.Foundation.IBMSDK.SpeechToText.Models
{
    public class Customization
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "customization_id")]
        public string CustomizationId { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "created")]
        public string Created { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "language")]
        public string Language { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "owner")]
        public string Owner { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "base_model_name")]
        public string BaseModelName { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "progress")]
        public int Progress { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "warnings")]
        public string Warnings { get; set; }
    }
}