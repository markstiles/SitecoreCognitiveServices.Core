
using SitecoreCognitiveServices.Foundation.MSSDK.Knowledge.Models.EntityLinking;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Knowledge
{
    public interface IEntityLinkingRepository
    {
        EntityLink[] Link(string text, string selection = "", int offset = 0);
        Task<EntityLink[]> LinkAsync(string text, string selection = "", int offset = 0);
    }
}
