using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Decision.Models.Personalizer
{
    public class RankRequest
    {
        public List<object> contextFeatures { get; set; }
        public List<RankableAction> actions { get; set; }
        public List<string> excludedActions { get; set; }
        public string eventId { get; set; }
        public bool deferActivation { get; set; }
    }
}