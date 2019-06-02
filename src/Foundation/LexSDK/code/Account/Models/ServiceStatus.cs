using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Account.Models
{
    public class ServiceStatus
    {
        public float api_version { get; set; }
        public string service_status { get; set; }
        public string service_version { get; set; }
        public string supported_compression { get; set; }
        public string supported_encoding { get; set; }
        public string[] supported_languages { get; set; }
    }
}