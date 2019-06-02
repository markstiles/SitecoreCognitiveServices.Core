using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Knowledge.Models.Recommendations
{
    public class Upsale
    {
        public List<string> ItemIds { get; set; }
        public int NumberOfItemsToUpsale { get; set; }
    }
}