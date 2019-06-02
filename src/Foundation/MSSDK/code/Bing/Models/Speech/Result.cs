﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Bing.Models.Speech {
    public class Result {
        public string Name { get; set; }
        public string Lexical { get; set; }
        public SpeechToTextToken[] Tokens { get; set; }
        public ResultProperties Properties { get; set; }
    }
}
