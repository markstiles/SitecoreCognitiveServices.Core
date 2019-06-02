using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.VisualRecognition.Models
{
    public class GetClassifiersBriefResponse
    {
        public List<GetClassifierBriefResponse> classifiers { get; set; }
    }
}
