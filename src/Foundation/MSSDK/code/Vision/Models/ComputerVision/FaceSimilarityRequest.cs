﻿using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using System;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Vision.Models.ComputerVision {
    
    public class FaceSimilarityRequest {
        public Guid FaceId { get; set; }
        public Guid[] FaceIds { get; set; }
        public string FaceListId { get; set; }
        public int MaxNumOfCandidatesReturned { get; set; }
        public FindSimilarMatchMode Mode { get; set; }
    }
}
