﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Language.Models.Luis {
    public class ApplicationFeaturesResponse {
        public PhraseListFeature[] PhraselistFeatures { get; set; }
        public PatternFeature[] PatternFeatures { get; set; }
    }
}