﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Language.Models.Luis {
    public class Entitylabel {
        public string EntityName { get; set; }
        public int StartTokenIndex { get; set; }
        public int EndTokenIndex { get; set; }
    }
}