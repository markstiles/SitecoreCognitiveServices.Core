using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.VisualRecognition.Models
{
    public class Faces
    {
        public int images_processed { get; set; }
        public List<FacesTopLevelSingle> images { get; set; }
        public List<WarningInfo> warnings { get; set; }
    }
}
