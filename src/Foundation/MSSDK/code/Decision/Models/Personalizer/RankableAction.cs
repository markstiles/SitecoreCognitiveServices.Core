using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Decision.Models.Personalizer
{
    public class RankableAction
    {
        public string id { get; set; }
        public List<object> features { get; set; }
    }
}