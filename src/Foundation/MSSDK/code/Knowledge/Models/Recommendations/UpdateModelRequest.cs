using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Knowledge.Models.Recommendations
{
    public class UpdateModelRequest
    {
        public string Description { get; set; }
        public int ActiveBuildId { get; set; }
    }
}