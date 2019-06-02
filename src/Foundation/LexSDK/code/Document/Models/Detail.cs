using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Document.Models
{
    public class Detail
    {
        public bool is_imperative { get; set; }
        public bool is_polar { get; set; }
        public Word[] words { get; set; }
    }
}