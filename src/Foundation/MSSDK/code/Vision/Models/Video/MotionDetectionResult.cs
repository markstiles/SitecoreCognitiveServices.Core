﻿using System;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Vision.Models.Video
{
    public class MotionDetectionResult
    {
        public string Status { get; set; }
        public int Progress { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastActionDateTime { get; set; }
        public MotionDetectionAnalysis ProcessingResult { get; set; }
    }
}