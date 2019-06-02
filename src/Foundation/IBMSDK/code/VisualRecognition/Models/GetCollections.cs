using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.VisualRecognition.Models
{
    public class GetCollections
    {
        public List<CreateCollection> collections { get; set; }
    }
}
