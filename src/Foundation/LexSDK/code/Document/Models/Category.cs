using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Document.Models
{
    public class Category
    {
        public string title { get; set; }
        public string type { get; set; }
        public float strength_score { get; set; }
    }
}