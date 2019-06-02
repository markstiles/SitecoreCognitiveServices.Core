using System.Collections.Generic;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.VisualRecognition.Models
{
    public class ClassifyPost
    {
        public int custom_classes { get; set; }
        public List<Classifiers> images { get; set; }
    }
}
