using SitecoreCognitiveServices.Foundation.NexSDK.Http.Enums;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Http.Models
{
    public class StatusMessage
    {
        public MessageSeverity Severity { get; set; } = MessageSeverity.Informational;
        public string Message { get; set; }
    }
}