using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK.Sources.Models
{
    public class ItemAnalysis
    {
        public string separator { get; set; }
        public int limit { get; set; }
        public string pruning_strategy { get; set; }
        public string separator_regexp { get; set; }
        public float target_frequency { get; set; }
    }
}