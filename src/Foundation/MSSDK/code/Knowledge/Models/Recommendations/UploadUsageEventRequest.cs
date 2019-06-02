using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Knowledge.Models.Recommendations
{
    public class UploadUsageEventRequest
    {
        public string UserId { get; set; }
        public int BuildId { get; set; }
        public List<UsageEvent> Events { get; set; }
    }
}