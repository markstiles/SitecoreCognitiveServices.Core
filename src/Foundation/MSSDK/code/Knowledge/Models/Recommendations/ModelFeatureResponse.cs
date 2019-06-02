using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Knowledge.Models.Recommendations
{
    public class ModelFeatureResponse
    {
        public int RankBuildId { get; set; }
        public string RankBuildDate { get; set; }
        public List<ModelFeature> Features { get; set; }
    }
}