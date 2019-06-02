using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Knowledge.Models.Recommendations
{
    public class FeatureWhiteList
    {
        public string Name { get; set; }
        public List<string> Values { get; set; }
    }
}