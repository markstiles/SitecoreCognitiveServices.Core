﻿using System.Collections.Generic;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Bing.Models.SpellCheck
{
    public class SpellCheckResponse
    {
        public string _type { get; set; }
        public List<SpellCheckToken> FlaggedTokens { get; set; }
    }
}