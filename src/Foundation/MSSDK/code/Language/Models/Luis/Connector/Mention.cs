﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Language.Models.Luis.Connector {
    public class Mention : Entity {
        public ChannelAccount Mentioned { get; set; }

        public string Text { get; set; }

        /// <summary>
        /// Initializes a new instance of the Entity class.
        /// 
        /// </summary>
        public Mention()
          : base("mention") {
        }
    }
}
