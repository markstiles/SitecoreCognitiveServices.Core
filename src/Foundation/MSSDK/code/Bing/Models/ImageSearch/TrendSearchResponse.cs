﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Bing.Models.ImageSearch {
    public class TrendSearchResponse
    {
        public string _type { get; set; }
        public SearchInstrumentation Instrumentation { get; set; }
        public List<ImageSearchCategory> Categories { get; set; }
    }
}