﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Knowledge.Models.Recommendations
{
    public class BusinessRuleSet
    {
        public BlockList BlockList { get; set; }
        public Whitelist Whitelist { get; set; }
        public Upsale Upsale { get; set; }
        public PerSeedBlockList PerSeedBlockList { get; set; }
        public FeatureBlockList FeatureBlockList { get; set; }
        public FeatureWhiteList FeatureWhiteList { get; set; }
    }
}