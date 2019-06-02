using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Vision.Models.ComputerVision
{
    public class Celebrity : Rectangle
    {
        public string Name { get; set; }
        public double Confidence { get; set; }
    }
}