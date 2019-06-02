using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Vision.Models.ComputerVision
{
    public class Detail
    {
        public Celebrity[] Celebrities { get; set; }
        public Landmark[] Landmarks { get; set; }
    }
}