﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Knowledge.Models.Recommendations
{
    public class FrequentlyBoughtTogetherBuild
    {
        public int supportThreshold { get; set; }
        public int maxItemSetSize { get; set; }
        public int minimalScore { get; set; }
        public string similarityFunction { get; set; }
        public bool enableModelingInsights { get; set; }
        public string splitterStrategy { get; set; }
        public RandomSplitParameters randomSplitterParameters { get; set; }
        public DateSplitParameters dateSplitterParameters { get; set; }
        public int popularItemBenchmarkWindow { get; set; }
    }
}