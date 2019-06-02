using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Vision.Models.ContentModerator {
    public class VideoModerationConfiguration {
        public string version { get; set; }
        public VideoModerationOptions Options { get; set; }
    }
}