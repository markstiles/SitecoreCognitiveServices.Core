using System.Collections.Generic;
using Newtonsoft.Json;
using SitecoreCognitiveServices.Foundation.MSSDK.Language.Models.Text;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Language.Models.Text {
    public class TopicRequest : TextRequest
    {
        public TopicRequest() {
            Documents = new List<IDocument>();
            StopWords = new List<string>();
            TopicsToExclude = new List<string>();
        }

        [JsonProperty("stopWords")]
        public List<string> StopWords { get; set; }

        [JsonProperty("topicsToExclude")]
        public List<string> TopicsToExclude { get; set; }
    }
}