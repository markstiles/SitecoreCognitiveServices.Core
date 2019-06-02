using SitecoreCognitiveServices.Foundation.MSSDK.Language.Models.Luis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language.Models
{
    public interface IConversationContext
    {
        Guid AppId { get; set; }
        string Message { get; set; }
        LuisResult Result { get; set; }
        ItemContextParameters Parameters { get; set; }
        string QuitIntentName { get; set; }
        string FrustratedUserIntentName { get; set; }
        string ClearText { get; set; }
        string AcceptText { get; set; }
        string ConfirmText { get; set; }
    }
}