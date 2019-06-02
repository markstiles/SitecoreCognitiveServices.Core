﻿using System.Collections.Generic;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Vision.Models.ContentModerator
{
    public class FindFacesResponse
    {
        public List<FindFaceRectangle> Faces { get; set; }
        public int Count { get; set; }
        //public List<object> AdvancedInfo { get; set; }
        public bool Result { get; set; }
        public ResponseStatus Status { get; set; }
        public string TrackingId { get; set; }
    }
}