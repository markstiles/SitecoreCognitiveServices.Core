using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.VisualRecognition.Models
{
    public class ClassifyParameters
    {
        public string[] urls { get; set; }
        public string[] classifier_ids { get; set; }
        public string[] owners { get; set; }
        public float threshold { get; set; }
    }
}
