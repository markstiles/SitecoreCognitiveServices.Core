using System.Collections.Generic;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Bing.Models.VideoSearch {
    public class VideoSearchTrendResponse {
        public string _type { get; set; }
        public MediaInstrumentation Instrumentation { get; set; }
        public List<VideoSearchTile> BannerTiles { get; set; }
        public List<VideoSearchCategory> Categories { get; set; }  
    }
}