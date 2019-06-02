using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Category.Models
{
    public class CategoryItem
    {
        public string id { get; set; }
        public int modified { get; set; }
        public string name { get; set; }
        public string[] samples { get; set; }
        public float weight { get; set; }
    }
}