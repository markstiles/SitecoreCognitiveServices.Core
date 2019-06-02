﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Knowledge.Models.AcademicSearch {
    public class CalcHistogramResult {
        public string Attribute { get; set; }
        public int Distinct_Values { get; set; }
        public int Total_Count { get; set; }
        public List<CalcHistogram> Histogram { get; set; }
    }
}