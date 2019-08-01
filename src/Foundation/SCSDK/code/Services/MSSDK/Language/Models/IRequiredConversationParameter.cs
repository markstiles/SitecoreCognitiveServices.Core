﻿using SitecoreCognitiveServices.Foundation.MSSDK.Language.Models.Luis;
using SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language.Models
{
    public interface IConversationParameter
    {
        string ParamName { get; set;  }
        string ParamMessage { get; set; }
        IParameterResult GetParameter(string paramValue, IConversationContext context, ItemContextParameters parameters, IConversation conversation);
        IntentInput GetInput(ItemContextParameters parameters, IConversation conversation);
    }
}