using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Decision.Models.Personalizer
{
    public class Evaluation
    {
        public string id { get; set; }
        public string name { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public string jobId { get; set; }
        public string status { get; set; }
        public List<PolicyResult> policyResults { get; set; }
        public List<List<string>> FeatureImportance { get; set; }
    }
}