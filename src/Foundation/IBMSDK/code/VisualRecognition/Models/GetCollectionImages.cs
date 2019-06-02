using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.VisualRecognition.Models
{
    public class GetCollectionImages
    {
        public List<GetCollectionsBrief> images { get; set; }
    }
}
