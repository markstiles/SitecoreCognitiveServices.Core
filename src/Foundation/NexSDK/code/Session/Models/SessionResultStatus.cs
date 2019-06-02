using System;
using SitecoreCognitiveServices.Foundation.NexSDK.Http.Enums;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Session.Models
{
    public class SessionResultStatus 
    {
        public Guid SessionId { get; set; }
        public Status Status { get; set; }
    }
}