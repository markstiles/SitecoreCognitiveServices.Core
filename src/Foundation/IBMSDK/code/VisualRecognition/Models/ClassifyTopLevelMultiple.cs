using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.VisualRecognition.Models
{
    public class ClassifyTopLevelMultiple
    {
        public List<ClassifyTopLevelSingle> images { get; set; }
        public List<WarningInfo> warnings { get; set; }
    }
}
