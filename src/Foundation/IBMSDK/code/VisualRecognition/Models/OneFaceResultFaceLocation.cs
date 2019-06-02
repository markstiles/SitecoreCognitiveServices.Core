using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.VisualRecognition.Models
{
    public class OneFaceResultFaceLocation
    {
        public decimal? width { get; set; }
        public decimal? height { get; set; }
        public decimal? left { get; set; }
        public decimal? top { get; set; }
    }
}
