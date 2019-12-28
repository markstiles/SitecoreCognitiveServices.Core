using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Decision.Models.Personalizer
{
    public class RankRequest
    {
        public ContextFeature[] contextFeatures { get; set; }
        public Action[] actions { get; set; }
        public string[] excludedActions { get; set; }
        public string eventId { get; set; }
        public bool deferActivation { get; set; }
    }
}