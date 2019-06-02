﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Knowledge.Models.Recommendations
{
    public class BatchJobRequest
    {
        public BatchEntity Input { get; set; }
        public BatchEntity Output { get; set; }
        public BatchEntity Error { get; set; }
        public BatchJob Job { get; set; }
    }
}