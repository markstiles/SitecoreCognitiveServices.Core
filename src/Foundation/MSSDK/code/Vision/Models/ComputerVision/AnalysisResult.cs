﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Vision.Models.ComputerVision
{
    public class AnalysisResult {
        public Guid RequestId { get; set; }

        public Metadata Metadata { get; set; }

        public ImageType ImageType { get; set; }

        public Color Color { get; set; }

        public Adult Adult { get; set; }

        public Category[] Categories { get; set; }

        public SimpleFace[] Faces { get; set; }

        public Tag[] Tags { get; set; }

        public Description Description { get; set; }
    }
}
