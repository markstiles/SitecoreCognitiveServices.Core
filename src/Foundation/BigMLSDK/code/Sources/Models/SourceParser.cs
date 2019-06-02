using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK.Sources.Models
{
    public class SourceParser
    {
        public bool header { get; set; }
        public string locale { get; set; }
        public string[] missing_tokens { get; set; }
        public string quote { get; set; }
        public string separator { get; set; }
        public bool trim { get; set; }
    }
}