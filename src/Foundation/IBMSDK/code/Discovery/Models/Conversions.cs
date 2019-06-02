using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models
{
    public class Conversions
    {
        [JsonProperty("pdf", NullValueHandling = NullValueHandling.Ignore)]
        public PdfSettings Pdf { get; set; }
        [JsonProperty("word", NullValueHandling = NullValueHandling.Ignore)]
        public WordSettings Word { get; set; }
        [JsonProperty("html", NullValueHandling = NullValueHandling.Ignore)]
        public HtmlSettings Html { get; set; }
        [JsonProperty("json_normalizations", NullValueHandling = NullValueHandling.Ignore)]
        public List<NormalizationOperation> JsonNormalizations { get; set; }
    }
}
