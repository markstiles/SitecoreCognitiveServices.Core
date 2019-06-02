using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Account.Models
{
    public class Statistics
    {
        public int batches_queued { get; set; }
        public int calls_data { get; set; }
        public int calls_polling { get; set; }
        public int calls_settings { get; set; }
        public string consumer_name { get; set; }
        public int docs_failed { get; set; }
        public int docs_queued { get; set; }
        public string latest_used_app { get; set; }
        public int total_api_calls { get; set; }
    }
}