﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Vision.Models.Face {
    public class SimilarPersistedFace {
        public Guid PersistedFaceId { get; set; }

        public double Confidence { get; set; }
    }
}
