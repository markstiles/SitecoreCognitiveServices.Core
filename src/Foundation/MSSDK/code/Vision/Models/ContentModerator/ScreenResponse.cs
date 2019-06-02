﻿using System.Collections.Generic;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Vision.Models.ContentModerator
{
    public class ScreenResponse
    {
        public string OriginalText { get; set; }
        public string NormalizedText { get; set; }
        public string AutoCorrectedText { get; set; }
        public List<ScreenUrl> Urls { get; set; }
        //public object Misrepresentation { get; set; }
        public PersonalIdentifiableInformation PII { get; set; }
        public string Language { get; set; }
        public List<TermSet> Terms { get; set; }
        public ResponseStatus Status { get; set; }
        public string TrackingId { get; set; }
    }
}