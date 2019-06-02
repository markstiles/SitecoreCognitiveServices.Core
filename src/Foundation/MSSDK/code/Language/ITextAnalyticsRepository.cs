using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.MSSDK.Language.Models.Text;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Common;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Language
{
    public interface ITextAnalyticsRepository
    {
        LanguageResponse GetLanguages(LanguageRequest request);
        Task<LanguageResponse> GetLanguagesAsync(LanguageRequest request);
        KeyPhraseSentimentResponse GetKeyPhrases(SentimentRequest request);
        Task<KeyPhraseSentimentResponse> GetKeyPhrasesAsync(SentimentRequest request);
        string GetTopics(TopicRequest request);
        Task<string> GetTopicsAsync(TopicRequest request);
        OperationResult GetOperation(string operationLocationUrl);
        Task<OperationResult> GetOperationAsync(string operationLocationUrl);
        SentimentResponse GetSentiment(SentimentRequest request);
        Task<SentimentResponse> GetSentimentAsync(SentimentRequest request);
    }
}
