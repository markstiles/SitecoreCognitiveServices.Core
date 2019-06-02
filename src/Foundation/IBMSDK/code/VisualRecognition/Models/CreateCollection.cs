using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.VisualRecognition.Models
{
    public class CreateCollection
    {
        public string collection_id { get; set; }
        public string name { get; set; }
        public string created { get; set; }
        public int? images { get; set; }
        public string status { get; set; }
        public string capacity { get; set; }
    }
}
