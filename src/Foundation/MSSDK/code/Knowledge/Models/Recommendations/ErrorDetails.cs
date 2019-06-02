using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Knowledge.Models.Recommendations
{
    public class ErrorDetails
    {
        public string ErrorCode { get; set; }
        public string ErrorText { get; set; }
        public List<ErrorLines> SampleErrorLines { get; set; }
    }
}