using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Knowledge.Models.Recommendations
{
    public class CreateModelRequest
    {
        public string ModelName { get; set; }
        public string Description { get; set; }
    }
}