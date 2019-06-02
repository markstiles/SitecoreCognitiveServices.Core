using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Knowledge.Models.AcademicSearch {
    public class AcademicAuthor {
        [JsonProperty(PropertyName = "return")]
        public AcademicReturn Return { get; set; }
    }
}