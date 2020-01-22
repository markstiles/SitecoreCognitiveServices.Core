using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace SitecoreCognitiveServices.Foundation.SCSDK {
    public interface ISCSDKSettings {
        string CoreDatabase { get; }
        string MasterDatabase { get; }
        string WebDatabase { get; }
        ID BigMLSDKId { get; }
        ID IBMSDKId { get; }
        ID LexSDKId { get; }
        ID MSSDKId { get; }
        ID NexSDKId { get; }
        bool CatchAndReleaseExceptions { get; }
        string SitecoreIndexNameFormat { get; }

        #region BigML

        #endregion

        #region IBMSDK
        ID IBMSDK_AssistantUsernameFieldId { get; }
        ID IBMSDK_AssistantPasswordFieldId { get; }
        ID IBMSDK_AssistantEndpointFieldId { get; }
        ID IBMSDK_AssistantRetryInSecondsFieldId { get; }
        ID IBMSDK_DiscoveryUsernameFieldId { get; }
        ID IBMSDK_DiscoveryPasswordFieldId { get; }
        ID IBMSDK_DiscoveryEndpointFieldId { get; }
        ID IBMSDK_DiscoveryRetryInSecondsFieldId { get; }
        ID IBMSDK_KnowledgeCatalogEndpointFieldId { get; }
        ID IBMSDK_KnowledgeCatalogUsernameFieldId { get; }
        ID IBMSDK_KnowledgeCatalogPasswordFieldId { get; }
        ID IBMSDK_KnowledgeCatalogRetryInSecondsFieldId { get; }
        ID IBMSDK_KnowledgeStudioEndpointFieldId { get; }
        ID IBMSDK_KnowledgeStudioUsernameFieldId { get; }
        ID IBMSDK_KnowledgeStudioPasswordFieldId { get; }
        ID IBMSDK_KnowledgeStudioRetryInSecondsFieldId { get; }
        ID IBMSDK_LanguageTranslatorUsernameFieldId { get; }
        ID IBMSDK_LanguageTranslatorPasswordFieldId { get; }
        ID IBMSDK_LanguageTranslatorEndpointFieldId { get; }
        ID IBMSDK_LanguageTranslatorRetryInSecondsFieldId { get; }
        ID IBMSDK_MachineLearningEndpointFieldId { get; }
        ID IBMSDK_MachineLearningUsernameFieldId { get; }
        ID IBMSDK_MachineLearningPasswordFieldId { get; }
        ID IBMSDK_MachineLearningRetryInSecondsFieldId { get; }
        ID IBMSDK_NaturalLanguageClassifierEndpointFieldId { get; }
        ID IBMSDK_NaturalLanguageClassifierUsernameFieldId { get; }
        ID IBMSDK_NaturalLanguageClassifierPasswordFieldId { get; }
        ID IBMSDK_NaturalLanguageClassifierRetryInSecondsFieldId { get; }
        ID IBMSDK_NaturalLanguageUnderstandingEndpointFieldId { get; }
        ID IBMSDK_NaturalLanguageUnderstandingUsernameFieldId { get; }
        ID IBMSDK_NaturalLanguageUnderstandingPasswordFieldId { get; }
        ID IBMSDK_NaturalLanguageUnderstandingRetryInSecondsFieldId { get; }
        ID IBMSDK_PersonalityInsightsUsernameFieldId { get; }
        ID IBMSDK_PersonalityInsightsPasswordFieldId { get; }
        ID IBMSDK_PersonalityInsightsEndpointFieldId { get; }
        ID IBMSDK_PersonalityInsightsRetryInSecondsFieldId { get; }
        ID IBMSDK_SpeechToTextUsernameFieldId { get; }
        ID IBMSDK_SpeechToTextPasswordFieldId { get; }
        ID IBMSDK_SpeechToTextEndpointFieldId { get; }
        ID IBMSDK_SpeechToTextRetryInSecondsFieldId { get; }
        ID IBMSDK_TextToSpeechUsernameFieldId { get; }
        ID IBMSDK_TextToSpeechPasswordFieldId { get; }
        ID IBMSDK_TextToSpeechEndpointFieldId { get; }
        ID IBMSDK_TextToSpeechRetryInSecondsFieldId { get; }
        ID IBMSDK_ToneAnalyzerUsernameFieldId { get; }
        ID IBMSDK_ToneAnalyzerPasswordFieldId { get; }
        ID IBMSDK_ToneAnalyzerEndpointFieldId { get; }
        ID IBMSDK_ToneAnalyzerRetryInSecondsFieldId { get; }
        ID IBMSDK_VisualRecognitionFieldId { get; }
        ID IBMSDK_VisualRecognitionEndpointFieldId { get; }
        ID IBMSDK_VisualRecognitionRetryInSecondsFieldId { get; }
        #endregion

        #region LexSDK
        ID LexSDK_ApiVersionFieldId { get; }
        ID LexSDK_AppNameFieldId { get; }
        ID LexSDK_AuthHostFieldId { get; }
        ID LexSDK_AuthAppKeyFieldId { get; }
        ID LexSDK_ConsumerKeyFieldId { get; }
        ID LexSDK_ConsumerSecretFieldId { get; }
        ID LexSDK_FormatFieldId { get; }
        ID LexSDK_HostFieldId { get; }
        ID LexSDK_PasswordFieldId { get; }
        ID LexSDK_UseCompressionFieldId { get; }
        ID LexSDK_UsernameFieldId { get; }
        ID LexSDK_WrapperNameFieldId { get; }
        #endregion

        #region MSSDK
        ID MSSDK_AcademicFieldId { get; }
        ID MSSDK_AcademicEndpointFieldId { get; }
        ID MSSDK_AcademicRetryInSecondsFieldId { get; }
        ID MSSDK_BingAutosuggestFieldId { get; }
        ID MSSDK_BingAutosuggestEndpointFieldId { get; }
        ID MSSDK_BingAutosuggestRetryInSecondsFieldId { get; }
        ID MSSDK_BingSearchFieldId { get; }
        ID MSSDK_BingSearchEndpointFieldId { get; }
        ID MSSDK_BingSearchRetryInSecondsFieldId { get; }
        ID MSSDK_BingSpellCheckFieldId { get; }
        ID MSSDK_BingSpellCheckEndpointFieldId { get; }
        ID MSSDK_BingSpellCheckRetryInSecondsFieldId { get; }
        ID MSSDK_ComputerVisionFieldId { get; }
        ID MSSDK_ComputerVisionEndpointFieldId { get; }
        ID MSSDK_ComputerVisionRetryInSecondsFieldId { get; }
        ID MSSDK_ContentModeratorFieldId { get; }
        ID MSSDK_ContentModeratorClientIdFieldId { get; }
        ID MSSDK_ContentModeratorPrivateKeyFieldId { get; }
        ID MSSDK_ContentModeratorEndpointFieldId { get; }
        ID MSSDK_ContentModeratorRetryInSecondsFieldId { get; }
        ID MSSDK_EntityLinkingFieldId { get; }
        ID MSSDK_EntityLinkingEndpointFieldId { get; }
        ID MSSDK_EntityLinkingRetryInSecondsFieldId { get; }
        ID MSSDK_FaceFieldId { get; }
        ID MSSDK_FaceEndpointFieldId { get; }
        ID MSSDK_FaceRetryInSecondsFieldId { get; }
        ID MSSDK_LuisFieldId { get; }
        ID MSSDK_LuisAuthoringFieldId { get; }
        ID MSSDK_LuisEndpointFieldId { get; }
        ID MSSDK_LuisRetryInSecondsFieldId { get; }
        ID MSSDK_LuisIntentConfidenceThresholdFieldId { get; }
        ID MSSDK_PersonalizerFieldId { get; }
        ID MSSDK_PersonalizerEndpointFieldId { get; }
        ID MSSDK_PersonalizerRetryInSecondsFieldId { get; }
        ID MSSDK_QnAFieldId { get; }
        ID MSSDK_QnAEndpointFieldId { get; }
        ID MSSDK_QnARetryInSecondsFieldId { get; }
        ID MSSDK_SpeakerRecognitionFieldId { get; }
        ID MSSDK_SpeakerRecognitionEndpointFieldId { get; }
        ID MSSDK_SpeakerRecognitionRetryInSecondsFieldId { get; }
        ID MSSDK_SpeechFieldId { get; }
        ID MSSDK_SpeechEndpointFieldId { get; }
        ID MSSDK_SpeechTokenEndpointFieldId { get; }
        ID MSSDK_SpeechRetryInSecondsFieldId { get; }
        ID MSSDK_TextAnalyticsFieldId { get; }
        ID MSSDK_TextAnalyticsEndpointFieldId { get; }
        ID MSSDK_TextAnalyticsRetryInSecondsFieldId { get; }
        ID MSSDK_VideoFieldId { get; }
        ID MSSDK_VideoEndpointFieldId { get; }
        ID MSSDK_VideoRetryInSecondsFieldId { get; }
        #endregion
        
        #region NexSDK 
        ID NexSDK_ApiTokenFieldId { get; }
        ID NexSDK_ClientVersionFieldId { get; }
        ID NexSDK_EndpointFieldId { get; }
        #endregion
    }
}