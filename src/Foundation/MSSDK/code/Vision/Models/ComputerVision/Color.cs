using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Vision.Models.ComputerVision
{
    public class Color {
        public string AccentColor { get; set; }

        public string DominantColorForeground { get; set; }

        public string DominantColorBackground { get; set; }

        public string[] DominantColors { get; set; }

        public bool IsBWImg { get; set; }
    }
}
