﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Knowledge.Models.AcademicSearch {
    public class InterpretResponse
    {
        public string Query { get; set; }
        public List<InterpretResult> Interpretations { get; set; }
    }
}