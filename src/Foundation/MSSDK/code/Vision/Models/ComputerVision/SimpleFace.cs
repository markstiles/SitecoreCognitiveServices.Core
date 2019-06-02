using SitecoreCognitiveServices.Foundation.MSSDK.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Vision.Models.ComputerVision {
    public class SimpleFace {
        public int Age { get; set; }

        public string Gender { get; set; }

        public Rectangle FaceRectangle { get; set; }
    }
}
