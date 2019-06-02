using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.VisualRecognition.Models
{
    public class FacesTopLevelSingle
    {
        public string source_url { get; set; }
        public string resolved_url { get; set; }
        public string image { get; set; }
        public ErrorInfoNoCode error { get; set; }
        public List<OneFaceResult> faces { get; set; }
    }
}
