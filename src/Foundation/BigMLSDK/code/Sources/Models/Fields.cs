using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK.Sources.Models
{
    public class Fields
    {
        public int column_number { get; set; }
        public ItemAnalysis item_analysis { get; set; }
        public string label { get; set; }
        // en-US
        public string locale { get; set; }
        public string[] missing_tokens { get; set; }
        public string name { get; set; }
        public string optype { get; set; }
        public TermAnalysis term_analysis  { get; set; }
    }
}