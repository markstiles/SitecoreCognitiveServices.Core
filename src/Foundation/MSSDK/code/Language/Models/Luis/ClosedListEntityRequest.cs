﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Language.Models.Luis {
    public class ClosedListEntityRequest {
        public string Name { get; set; }
        public ClosedListEntity[] Sublists { get; set; }
    }
}