
namespace SitecoreCognitiveServices.Foundation.IBMSDK
{
    public interface IIBMWatsonApiKeys
    {
        string AssistantEndpoint{ get; }
        string AssistantUsername{ get; }
        string AssistantPassword{ get; }
        int AssistantRetryInSeconds{ get; }

        string DiscoveryEndpoint{ get; }
        string DiscoveryUsername{ get; }
        string DiscoveryPassword{ get; }
        int DiscoveryRetryInSeconds{ get; }

        string KnowledgeCatalogEndpoint{ get; }
        string KnowledgeCatalogUsername{ get; }
        string KnowledgeCatalogPassword{ get; }
        int KnowledgeCatalogRetryInSeconds{ get; }

        string KnowledgeStudioEndpoint{ get; }
        string KnowledgeStudioUsername{ get; }
        string KnowledgeStudioPassword{ get; }
        int KnowledgeStudioRetryInSeconds{ get; }

        string LanguageTranslatorEndpoint{ get; }
        string LanguageTranslatorUsername{ get; }
        string LanguageTranslatorPassword{ get; }
        int LanguageTranslatorRetryInSeconds{ get; }

        string MachineLearningEndpoint{ get; }
        string MachineLearningUsername{ get; }
        string MachineLearningPassword{ get; }
        int MachineLearningRetryInSeconds{ get; }
        
        string NaturalLanguageClassifierEndpoint{ get; }
        string NaturalLanguageClassifierUsername{ get; }
        string NaturalLanguageClassifierPassword{ get; }
        int NaturalLanguageClassifierRetryInSeconds{ get; }

        string NaturalLanguageUnderstandingEndpoint{ get; }
        string NaturalLanguageUnderstandingUsername{ get; }
        string NaturalLanguageUnderstandingPassword{ get; }
        int NaturalLanguageUnderstandingRetryInSeconds{ get; }

        string PersonalityInsightsEndpoint{ get; }
        string PersonalityInsightsUsername{ get; }
        string PersonalityInsightsPassword{ get; }
        int PersonalityInsightsRetryInSeconds{ get; }

        string SpeechToTextEndpoint{ get; }
        string SpeechToTextUsername{ get; }
        string SpeechToTextPassword{ get; }
        int SpeechToTextRetryInSeconds{ get; }

        string TextToSpeechEndpoint{ get; }
        string TextToSpeechUsername{ get; }
        string TextToSpeechPassword{ get; }
        int TextToSpeechRetryInSeconds{ get; }

        string ToneAnalyzerEndpoint{ get; }
        string ToneAnalyzerUsername{ get; }
        string ToneAnalyzerPassword{ get; }
        int ToneAnalyzerRetryInSeconds{ get; }

        string VisualRecognition{ get; }
        string VisualRecognitionEndpoint{ get; }
        int VisualRecognitionRetryInSeconds{ get; }
    }
}
