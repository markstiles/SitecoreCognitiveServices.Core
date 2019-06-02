using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK.Sources.Models
{
    public class SyntheticSource
    {
        public int cat_padding { get; set; }
        public int fields { get; set; }
        public float frac_cat { get; set; }
        public float optional { get; set; }
        public float frac_time { get; set; }
        public float missing { get; set; }
        public float noise { get; set; }
        public int num_cats { get; set; }
        public int num_classes { get; set; }
        public int rows { get; set; }
        public float sparsity { get; set; }
    }
}