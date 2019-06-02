using System.Runtime.Serialization;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Http.Enums
{
    public enum MessageSeverity
    {
        [EnumMember(Value = "debug")]
        Debug = -1,

        [EnumMember(Value = "informational")]
        Informational = 0,

        [EnumMember(Value = "warning")]
        Warning = 1,

        [EnumMember(Value = "error")]
        Error = 2
    }
}