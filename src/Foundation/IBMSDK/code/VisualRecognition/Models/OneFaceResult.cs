using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.VisualRecognition.Models
{
    public class OneFaceResult
    {
        public OneFaceResultAge age { get; set; }
        public OneFaceResultGender gender { get; set; }
        public OneFaceResultFaceLocation face_location { get; set; }
        public OneFaceResultIdentity identity { get; set; }
    }
}
