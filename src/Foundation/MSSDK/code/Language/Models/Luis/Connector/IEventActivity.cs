﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Language.Models.Luis.Connector {
    public interface IEventActivity : IActivity {
        /// <summary>
        /// Name of the event
        /// 
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Open-ended value
        /// 
        /// </summary>
        object Value { get; set; }

        /// <summary>
        /// Reference to another conversation or activity
        /// 
        /// </summary>
        ConversationReference RelatesTo { get; set; }
    }
}
