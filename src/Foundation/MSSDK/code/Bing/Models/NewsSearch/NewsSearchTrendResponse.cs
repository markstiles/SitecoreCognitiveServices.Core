﻿using System.Collections.Generic;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Bing.Models.NewsSearch {
    public class NewsSearchTrendResponse {
        public string _type { get; set; }
        public MediaInstrumentation Instrumentation { get; set; }
        public List<NewsSearchTopicResult> Value { get; set; }
    }
}