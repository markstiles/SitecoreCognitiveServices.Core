using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Language.Models.Text {
    public class DocumentError {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
