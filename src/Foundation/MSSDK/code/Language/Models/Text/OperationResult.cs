﻿using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Common {
    public class OperationResult {
        public OperationStatus Status { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime LastActionDateTime { get; set; }

        public string Message { get; set; }

        public string ResourceLocation { get; set; }

        public string ProcessingResult { get; set; }
    }
}
