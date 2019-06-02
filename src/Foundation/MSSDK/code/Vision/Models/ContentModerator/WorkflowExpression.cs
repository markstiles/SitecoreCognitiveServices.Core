
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Vision.Models.ContentModerator
{
    public class WorkflowExpression
    {
        public string Description { get; set; }
        public IExpression Expression { get; set; }
        public ContentModeratorReviewType Type { get; set; }
    }
}