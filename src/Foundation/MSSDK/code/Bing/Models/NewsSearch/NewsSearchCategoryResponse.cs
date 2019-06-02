using System.Collections.Generic;
using SitecoreCognitiveServices.Foundation.MSSDK.Bing.Models.WebSearch;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Bing.Models.NewsSearch {
    public class NewsSearchCategoryResponse {
        public string _type { get; set; }
        public List<WebSearchNewsResult> Value { get; set; } 
    }
}