using SitecoreCognitiveServices.Foundation.MSSDK.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Speech.Models {
    public class EnrollmentOperation : Operation {
        public Enrollment ProcessingResult { get; set; }
    }
}
