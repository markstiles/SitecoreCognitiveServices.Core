﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Knowledge.Models.Recommendations
{
    public class CreateBusinessRuleResponse
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public BusinessRuleSet Parameters { get; set; }
    }
}