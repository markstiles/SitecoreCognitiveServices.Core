using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Language.Models.Luis {
    public class PhraseListFeature {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phrases { get; set; }
        public bool IsExchangeable { get; set; }
        public bool IsActive { get; set; }
    }
}