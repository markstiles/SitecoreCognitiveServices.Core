﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Language.Models.Luis {
    public class ClosedListEntity {
        public int Id { get; set; }
        public string CanonicalForm { get; set; }
        public string[] List { get; set; }
    }
}