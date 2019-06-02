using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Knowledge.Models.Recommendations
{
    public class CreateBuildRequest
    {
        public string Description { get; set; }
        public string BuildType { get; set; }
        public BuildSet Parameters { get; set; }
    }
}