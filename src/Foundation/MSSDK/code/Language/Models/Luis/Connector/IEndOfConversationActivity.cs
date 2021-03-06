﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Language.Models.Luis.Connector {
    public interface IEndOfConversationActivity : IActivity {
        /// <summary>
        /// Code indicating why the conversation has ended
        /// 
        /// </summary>
        string Code { get; set; }

        /// <summary>
        /// Content to display when ending the conversation
        /// 
        /// </summary>
        string Text { get; set; }

        /// <summary>
        /// Collection of Entity objects, each of which contains metadata about this activity. Each Entity object is typed.
        /// 
        /// </summary>
        IList<Entity> Entities { get; set; }
    }
}
