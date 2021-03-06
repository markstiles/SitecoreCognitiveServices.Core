﻿using System;
using System.Collections.Generic;
using SitecoreCognitiveServices.Foundation.MSSDK.Language.Models.Luis;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language.Models
{
    public interface IIntent {
        Guid ApplicationId { get; }
        string KeyName { get; }
        string DisplayName { get; }
        bool RequiresConfirmation { get; }
        List<IConversationParameter> ConversationParameters { get; }
        ConversationResponse Respond(LuisResult result, ItemContextParameters parameters, IConversation conversation);
    }
}