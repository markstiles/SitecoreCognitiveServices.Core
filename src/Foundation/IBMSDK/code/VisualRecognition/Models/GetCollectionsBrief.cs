using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.VisualRecognition.Models
{
    public class GetCollectionsBrief
    {
        public string image_id { get; set; }
        public string created { get; set; }
        public string image_file { get; set; }
        public object metadata { get; set; }
    }
}
