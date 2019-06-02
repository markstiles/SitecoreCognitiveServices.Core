using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class HtmlSettings
    {
        [JsonProperty("exclude_tags_completely", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> ExcludeTagsCompletely { get; set; }
        [JsonProperty("exclude_tags_keep_content", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> ExcludeTagsKeepContent { get; set; }
        [JsonProperty("keep_content", NullValueHandling = NullValueHandling.Ignore)]
        public XPathPatterns KeepContent { get; set; }
        [JsonProperty("exclude_content", NullValueHandling = NullValueHandling.Ignore)]
        public XPathPatterns ExcludeContent { get; set; }
        [JsonProperty("keep_tag_attributes", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> KeepTagAttributes { get; set; }
        [JsonProperty("exclude_tag_attributes", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> ExcludeTagAttributes { get; set; }
    }
}
