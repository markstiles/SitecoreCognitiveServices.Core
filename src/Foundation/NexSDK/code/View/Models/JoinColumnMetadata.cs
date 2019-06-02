using SitecoreCognitiveServices.Foundation.NexSDK.Http.Enums;

namespace SitecoreCognitiveServices.Foundation.NexSDK.View.Models
{
    public class JoinColumnMetadata
    {
        public string Alias { get; set; }
        public ResultInterval? JoinInterval { get; set; }
        public string JoinTo { get; set; }
    }
}