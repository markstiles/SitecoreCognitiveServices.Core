﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Language.Models.Luis {
    public class ExternalApiKeySet {
        public string Type { get; set; }
        public List<string> Values { get; set; }
    }
}