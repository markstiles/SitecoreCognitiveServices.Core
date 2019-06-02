using System.Runtime.Serialization;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Import.Enums
{
    public enum ImportType
    {
        [EnumMember(Value = "s3")] S3 = 0,
        [EnumMember(Value = "url")] Url = 1,
        [EnumMember(Value = "azure")] Azure = 2,
    }
}