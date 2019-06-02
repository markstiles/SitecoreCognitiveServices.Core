using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK.Projects.Models
{
    public class Project
    {
        public int category { get; set; }
        public int code { get; set; }
        public DateTime created { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public bool _private { get; set; }
        public string resource { get; set; }
        public Stats stats { get; set; }
        public Status status { get; set; }
        public object[] tags { get; set; }
        public DateTime updated { get; set; }
        public Webhook webhook { get; set; }
    }
}