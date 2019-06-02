using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Bing.Models.AutoSuggest {
    public class AutoSuggestGroup
    {
        public string Name { get; set; }
        public List<AutoSuggestEntry> SearchSuggestions { get; set; }
    }
}