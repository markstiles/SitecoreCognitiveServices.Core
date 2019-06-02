using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Account.Models
{
    public class SupportedFeatures
    {
        public string id { get; set; }
        public string language { get; set; }
        public bool html_processing { get; set; }
        public SupportedFeatureSettings settings { get; set; }
        public DetailedMode detailed_mode { get; set; }
        public DiscoveryMode discovery_mode { get; set; }
    }
}