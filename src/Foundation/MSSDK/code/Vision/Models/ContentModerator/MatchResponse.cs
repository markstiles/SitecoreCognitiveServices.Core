﻿
namespace SitecoreCognitiveServices.Foundation.MSSDK.Vision.Models.ContentModerator
{
    public class MatchResponse
    {
        public string TrackingId { get; set; }
        public string CacheId { get; set; }
        public bool IsMatch { get; set; }
        public MatchDetails MatchDetails { get; set; }
    }
}