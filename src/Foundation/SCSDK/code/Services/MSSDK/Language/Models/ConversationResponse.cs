using System.Collections.Generic;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language.Models
{
    public class ConversationResponse
    {
        public string Message { get; set; }
        public string Intent { get; set; }
        public bool Ended { get; set; }
        public IntentInput Input { get; set; }
        public string Action { get; set; }
        public Dictionary<string, string> Selections { get; set; }
    }
}