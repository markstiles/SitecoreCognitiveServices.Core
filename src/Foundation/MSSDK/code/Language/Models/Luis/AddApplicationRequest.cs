﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Language.Models.Luis {
    public class AddApplicationRequest {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Culture { get; set; }
        public string UsageScenario { get; set; }
        public string Domain { get; set; }
        public string InitialVersionId { get; set; }
    }
}