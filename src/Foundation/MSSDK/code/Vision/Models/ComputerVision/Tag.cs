﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Vision.Models.ComputerVision {
    public class Tag {
        public string Name { get; set; }

        public double Confidence { get; set; }

        public string Hint { get; set; }
    }
}
