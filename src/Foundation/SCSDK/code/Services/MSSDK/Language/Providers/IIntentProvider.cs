using System;
using System.Collections.Generic;
using SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language.Models;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language.Providers
{
    public interface IIntentProvider
    {
        Dictionary<string, IIntent> GetAllIntents(Guid appId);

        IIntent GetIntent(Guid appId, string intentName);

        IIntent GetTopScoringIntent(IConversationContext context);

        ConversationResponse GetDefaultResponse(Guid appId);
    }
}