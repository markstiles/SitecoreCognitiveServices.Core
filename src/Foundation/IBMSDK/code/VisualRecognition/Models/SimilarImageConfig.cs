using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.VisualRecognition.Models
{
    public class SimilarImageConfig
    {
        public string image_id { get; set; }
        public string created { get; set; }
        public string image_file { get; set; }
        public Dictionary<string, string> metadata { get; set; }
        public float score { get; set; }
    }
}
