﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Language.Models.Luis {
    public class UtteranceEntity {
        public string Entity { get; set; }
        public int StartPos { get; set; }
        public int EndPos { get; set; }
    }
}