using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Account.Models
{
    public class SubscriptionFeatureSettings
    {
        public SubscriptionDocument document { get; set; }
        public SubscriptionCollection collection { get; set; }
        public bool html_processing { get; set; }
        public string supported_languages { get; set; }
    }
}