using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Document.Models
{
    public class Mention
    {
        public string label { get; set; }
        public bool is_negated { get; set; }
        public string negating_phrase { get; set; }
        public Location[] locations { get; set; }
    }
}