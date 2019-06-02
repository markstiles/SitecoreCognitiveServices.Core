﻿using System.Collections.Generic;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Bing.Models.VideoSearch {
    public class VideoSearchDetailsResponse {
        public string _type { get; set; }
        public SearchInstrumentation Instrumentation { get; set; }
        public List<VideoSearchRelatedResult> RelatedVideos { get; set; }
        public VideoSearchResult VideoResult { get; set; }  
    }
}