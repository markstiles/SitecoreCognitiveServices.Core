﻿using SitecoreCognitiveServices.Foundation.MSSDK.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Vision.Models.Face {
    public class Face {
        public Guid FaceId { get; set; }

        public Rectangle FaceRectangle { get; set; }

        public FaceLandmarks FaceLandmarks { get; set; }

        public FaceAttributes FaceAttributes { get; set; }
    }
}
