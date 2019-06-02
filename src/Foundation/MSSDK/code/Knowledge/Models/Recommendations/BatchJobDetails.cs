using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Knowledge.Models.Recommendations
{
    public class BatchJobDetails
    {
        public string Id { get; set; }
        public BatchJobRequest RequestInfo { get; set; }
        public string Status { get; set; }
    }
}