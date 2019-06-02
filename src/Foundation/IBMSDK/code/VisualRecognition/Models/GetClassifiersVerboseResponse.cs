using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.VisualRecognition.Models
{
    public class GetClassifiersVerboseResponse
    {
        public List<GetClassifierVerboseResponse> classifiers { get; set; }
    }
}
