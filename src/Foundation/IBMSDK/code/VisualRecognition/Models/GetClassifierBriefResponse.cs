using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.VisualRecognition.Models
{
    public class GetClassifierBriefResponse
    {
        public string classifier_id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
    }
}
