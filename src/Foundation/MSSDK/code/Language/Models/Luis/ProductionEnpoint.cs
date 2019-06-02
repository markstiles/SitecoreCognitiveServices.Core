﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Language.Models.Luis {
    public class ProductionEnpoint {
        public string VersionId { get; set; }
        public bool IsStaging { get; set; }
        public string EndpointUrl { get; set; }
        public string AssignedEndpointKey { get; set; }
        public DateTime PublishedDateTime { get; set; }
    }
}