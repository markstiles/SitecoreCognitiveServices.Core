using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Document.Models
{
    public class DocumentRequest
    {
        public string id { get; set; }
        public string text { get; set; }
        public string tag { get; set; }
        public Metadata metadata { get; set; }
    }
}