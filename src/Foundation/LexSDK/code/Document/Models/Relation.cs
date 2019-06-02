using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Document.Models
{
    public class Relation
    {
        public string type { get; set; }
        public string relation_type { get; set; }
        public float confidence_score { get; set; }
        public string extra { get; set; }
        public Entity[] entities { get; set; }
    }
}