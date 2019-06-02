﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Vision.Models.ContentModerator
{
    public class ConditionCombination : IExpression
    {
        public Condition Left { get; set; }
        public Condition Right { get; set; }
        /// <summary>
        /// Values (AND or OR)
        /// </summary>
        public string Combine { get; set; }
        public string Type => "Combine";
    }
}