using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Account.Models
{
    public class BillingSettings
    {
        public int data_calls_limit { get; set; }
        public int settings_calls_limit { get; set; }
        public int polling_calls_limit { get; set; }
        public int data_calls_limit_interval { get; set; }
        public int settings_calls_limit_interval { get; set; }
        public int polling_calls_limit_interval { get; set; }
        public int docs_balance { get; set; }
        public int settings_calls_balance { get; set; }
        public int polling_calls_balance { get; set; }
        public int data_calls_balance { get; set; }
        public long expiration_date { get; set; }
        public string limit_type { get; set; }
        public int docs_suggested { get; set; }
        public int docs_suggsted_interval { get; set; }
        public int job_ids_allocated { get; set; }
        public int job_ids_permitted { get; set; }
        public int app_seats_permitted { get; set; }
        public int app_seats_allocated { get; set; }
    }
}