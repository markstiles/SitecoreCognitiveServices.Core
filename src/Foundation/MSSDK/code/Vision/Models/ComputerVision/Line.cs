﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Common;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Vision.Models.ComputerVision
{
    public class Line
    {
        public string BoundingBox { get; set; }
        public string Text { get; set; }
        public Word[] Words { get; set; }
        public Rectangle Rectangle => Rectangle.FromString(BoundingBox);
    }
}
