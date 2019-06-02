using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.NexSDK.Vocabulary.Models;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.NexSDK
{
    public interface IVocabularyService
    {
        Task<VocabulariesSummary> List(VocabulariesQuery query = null);

        Task<VocabularyResponse> Get(VocabularyWordsQuery query);

        Task Remove(VocabularyRemoveCriteria criteria);
    }
}