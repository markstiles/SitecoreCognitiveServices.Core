using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Knowledge.Models.Recommendations
{
    public class UsageFile
    {
        public string FileId { get; set; }
        public string UsageDisplayName { get; set; }
        public float SizeInMegabytes { get; set; }
        public string DateModified { get; set; }
        public bool UsedInModel { get; set; }
    }
}