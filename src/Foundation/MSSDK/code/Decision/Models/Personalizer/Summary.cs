using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Decision.Models.Personalizer
{
    public class Summary
    {
        public DateTime timeStamp { get; set; }
        public float ipsEstimatorNumerator { get; set; }
        public int ipsEstimatorDenominator { get; set; }
        public float snipsEstimatorDenominator { get; set; }
        public string aggregateTimeWindow { get; set; }
        public int nonZeroProbability { get; set; }
        public float confidenceInterval { get; set; }
        public float sumOfSquares { get; set; }
    }
}