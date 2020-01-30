using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Decision.Models.Personalizer
{
    public class Summary
    {
        public DateTime timeStamp { get; set; }
        public double ipsEstimatorNumerator { get; set; }
        public double ipsEstimatorDenominator { get; set; }
        public double snipsEstimatorDenominator { get; set; }
        public TimeSpan aggregateTimeWindow { get; set; }
        public double nonZeroProbability { get; set; }
        public double confidenceInterval { get; set; }
        public double sumOfSquares { get; set; }
    }
}