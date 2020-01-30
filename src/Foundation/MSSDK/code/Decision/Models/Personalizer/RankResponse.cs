using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Decision.Models.Personalizer
{
    public class RankResponse
    {
        public List<Ranking> ranking { get; set; }
        public string eventId { get; set; }
        public string rewardActionId { get; set; }
    }
}