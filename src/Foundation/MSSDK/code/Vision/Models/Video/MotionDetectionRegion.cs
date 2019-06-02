﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Vision.Models.Video
{
    public class MotionDetectionRegion
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public List<XYPoint> Points { get; set; }
    }
}