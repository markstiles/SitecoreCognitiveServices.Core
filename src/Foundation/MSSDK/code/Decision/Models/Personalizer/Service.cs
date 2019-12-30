using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Decision.Models.Personalizer
{
    public class Service
    {
        public string rewardWaitTime { get; set; }
        public int defaultReward { get; set; }
        public string rewardAggregation { get; set; }
        public float explorationPercentage { get; set; }
        public string modelExportFrequency { get; set; }
        public int logRetentionDays { get; set; }
    }
}