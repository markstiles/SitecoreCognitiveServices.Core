using System.Collections.Generic;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Bing.Models.VideoSearch {
    public class VideoSearchCategory {
        public string Title { get; set; }
        public List<VideoSearchSubategory> Subcategories { get; set; }
    }
}