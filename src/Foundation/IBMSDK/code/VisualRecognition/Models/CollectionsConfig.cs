using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.VisualRecognition.Models
{
    public class CollectionsConfig
    {
        public List<CollectionImagesConfig> images { get; set; }
        public int images_processed { get; set; }
    }
}
