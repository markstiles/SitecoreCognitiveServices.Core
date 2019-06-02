using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK.Sources.Models
{
    public class Status
    {
        public int code { get; set; }
        public string message { get; set; }
        public int progress { get; set; }
    }
}