using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Decision.Models.Personalizer
{
    public class Action
    {
        public string id { get; set; }
        public Feature[] features { get; set; }
    }
}