﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Language.Models.Luis
{
    public class SentimentAnalysis
    {
        public string label { get; set; }
        public float score { get; set; }
    }
}