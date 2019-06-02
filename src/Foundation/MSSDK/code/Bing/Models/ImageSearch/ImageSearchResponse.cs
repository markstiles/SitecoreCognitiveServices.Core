﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Bing.Models.ImageSearch {
    public class ImageSearchResponse
    {
        public string _type { get; set; }
        public string ImageSearchInstrumentation { get; set; }
        public string ReadLink { get; set; }
        public string WebSearchUrl { get; set; }
        public int TotalEstimatedMatches { get; set; }
        public List<ImageSearchResult> Value { get; set; }
        public List<ImageSearchShortResult> QueryExpansions { get; set; }
        public int NextOffsetAddCount { get; set; }
        public List<SearchSuggestion<ImageSearchShortResult>> PivotSuggestions { get; set; }
        public bool DisplayShoppingSourcesBadges { get; set; }
        public bool DisplayRecipeSourcesBadge { get; set; }
        public List<ImageSearchQuickResult> SimilarTerms { get; set; }
    }
}