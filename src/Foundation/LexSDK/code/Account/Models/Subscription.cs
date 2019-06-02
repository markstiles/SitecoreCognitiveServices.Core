using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Account.Models
{
    public class Subscription
    {
        public string name { get; set; }
        public string status { get; set; }
        public BillingSettings billing_settings { get; set; }
        public BasicSettings basic_settings { get; set; }
        public SubscriptionFeatureSettings feature_settings { get; set; }
        public SubscriptionTemplate[] templates { get; set; }
    }
}