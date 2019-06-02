using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Account.Models
{
    public class SubscriptionTemplate
    {
        public string config_id { get; set; }
        public string id { get; set; }
        public bool is_free { get; set; }
        public string language { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public object version { get; set; }
    }
}