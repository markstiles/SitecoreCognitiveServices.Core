
namespace SitecoreCognitiveServices.Foundation.MSSDK
{
    public interface IMicrosoftCognitiveServicesApiKeys
    {
        string Academic { get; }
        string AcademicEndpoint { get; }
        int AcademicRetryInSeconds { get; }
        string BingSpellCheck { get; }
        string BingSpellCheckEndpoint { get; }
        int BingSpellCheckRetryInSeconds { get; }
        string BingAutosuggest { get; }
        string BingAutosuggestEndpoint { get; }
        int BingAutosuggestRetryInSeconds { get; }
        string BingSearch { get; }
        string BingSearchEndpoint { get; }
        int BingSearchRetryInSeconds { get; }
        string ComputerVision { get; }
        string ComputerVisionEndpoint { get; }
        int ComputerVisionRetryInSeconds { get; }
        string ContentModerator { get; }
        string ContentModeratorClientId { get; }
        string ContentModeratorPrivateKey { get; }
        string ContentModeratorEndpoint { get; }
        int ContentModeratorRetryInSeconds { get; }
        string EntityLinking { get; }
        string EntityLinkingEndpoint { get; }
        int EntityLinkingRetryInSeconds { get; }
        string Face { get; }
        string FaceEndpoint { get; }
        int FaceRetryInSeconds { get; }
        string Luis { get; }
        string LuisAuthoring { get; }
        string LuisEndpoint { get; }
        int LuisRetryInSeconds { get; }
        float LuisIntentConfidenceThreshold { get; }
        string QnA { get; }
        string QnAEndpoint { get; }
        int QnARetryInSeconds { get; }
        string Recommendations { get; }
        string RecommendationsEndpoint { get; }
        int RecommendationsRetryInSeconds { get; }
        string SpeakerRecognition { get; }
        string SpeakerRecognitionEndpoint { get; }
        int SpeakerRecognitionRetryInSeconds { get; }
        string Speech { get; }
        string SpeechEndpoint { get; }
        string SpeechTokenEndpoint { get; }
        int SpeechRetryInSeconds { get; }
        string TextAnalytics { get; }
        string TextAnalyticsEndpoint { get; }
        int TextAnalyticsRetryInSeconds { get; }
        string Video { get; }
        string VideoEndpoint { get; }
        int VideoRetryInSeconds { get; }
    }
}
