using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Vision.Models.ComputerVision
{
    public class AnalysisInDomainResult {
        public Guid RequestId { get; set; }

        public Metadata Metadata { get; set; }

        public object Result { get; set; }
    }
}
