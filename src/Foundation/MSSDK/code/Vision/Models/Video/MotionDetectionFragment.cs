﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Vision.Models.Video
{
    public class MotionDetectionFragment
    {
        public int Start { get; set; }
        public int Duration { get; set; }
        public int Interval { get; set; }
        public List<List<MotionDetectionEvent>> Events { get; set; }
    }
}