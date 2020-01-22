using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Decision.Models.Personalizer
{
    public class PolicyResult
    {
        public string name { get; set; }
        public string arguments { get; set; }
        public Summary[] summary { get; set; }
        public Summary totalSummary { get; set; }
    }
}