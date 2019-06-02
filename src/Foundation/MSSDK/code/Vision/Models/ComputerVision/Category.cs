using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Vision.Models.ComputerVision {
    public class Category {
        public ImageCategory Name { get; set; }
        public double Score { get; set; }
        public Detail Detail { get; set; }
    }
}
