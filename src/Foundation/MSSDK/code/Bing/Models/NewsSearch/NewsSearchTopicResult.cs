﻿
namespace SitecoreCognitiveServices.Foundation.MSSDK.Bing.Models.NewsSearch {
    public class NewsSearchTopicResult {
        public string Name { get; set; }
        public NewsSearchTopicImage Image { get; set; }
        public string WebSearchUrl { get; set; }
        public string WebSearchUrlPingSuffix { get; set; }
        public bool IsBreakingNews { get; set; }
    }
}