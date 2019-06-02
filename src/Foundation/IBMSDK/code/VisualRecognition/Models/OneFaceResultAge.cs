using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.VisualRecognition.Models
{
    public class OneFaceResultAge
    {
        public int? min { get; set; }
        public int? max { get; set; }
        public float score { get; set; }
    }
}
