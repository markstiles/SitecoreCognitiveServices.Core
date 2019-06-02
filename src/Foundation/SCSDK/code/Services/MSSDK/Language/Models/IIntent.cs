using System;
using System.Collections.Generic;
using SitecoreCognitiveServices.Foundation.MSSDK.Language.Models.Luis;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language.Models
{
    public interface IIntent {
        Guid ApplicationId { get; }
        string Name { get; }
        string Description { get; }
        bool RequiresConfirmation { get; }
        List<IRequiredConversationParameter> ConversationParameters { get; }
        ConversationResponse Respond(LuisResult result, ItemContextParameters parameters, IConversation conversation);
    }
}