using SitecoreCognitiveServices.Foundation.MSSDK.Knowledge.Models.EntityLinking;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Knowledge
{
    public interface IEntityLinkingService
    {
        EntityLink[] Link(string text, string selection = "", int offset = 0);
    }
}