using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.VisualRecognition.Models
{
    public class SimilarImagesConfig
    {
        public List<SimilarImageConfig> similar_images { get; set; }
        public int images_processed { get; set; }
    }
}
