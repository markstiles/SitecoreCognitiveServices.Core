using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.NexSDK.Vocabulary.Models;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Vocabulary
{
    public interface IVocabularyRepository
    {
        Task<VocabulariesSummary> List(VocabulariesQuery query = null);

        Task<VocabularyResponse> Get(VocabularyWordsQuery query);

        Task Remove(VocabularyRemoveCriteria criteria);
    }
}