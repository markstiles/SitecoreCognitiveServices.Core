using SitecoreCognitiveServices.Foundation.MSSDK.Language.Models.Luis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language.Models
{
    public class ConversationContext : IConversationContext
    {
        public Guid AppId { get; set; }
        public string Message { get; set; }
        public LuisResult Result { get; set; }
        public ItemContextParameters Parameters { get; set; }
        public string QuitIntentName { get; set; }
        public string FrustratedIntentName { get; set; }
        public string YesIntentName { get; set; }
        public string NoIntentName { get; set; }
        public string ClearText { get; set; }
        public string ConfirmText { get; set; }
    }
}