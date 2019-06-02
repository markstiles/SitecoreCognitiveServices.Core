using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK.Sources.Models
{
    public class FieldTypes
    {
        public int categorical { get; set; }
        public int datetime { get; set; }
        public int items { get; set; }
        public int numeric { get; set; }
        public int text { get; set; }
        public int total { get; set; }
    }
}