using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Configuration;
using Sitecore.Data;

namespace SitecoreCognitiveServices.Foundation.SCSDK {
    public class SCSDKSettings : ISCSDKSettings
    {
        public virtual string CoreDatabase => Settings.GetSetting("CognitiveService.CoreDatabase");
        public virtual string MasterDatabase => Settings.GetSetting("CognitiveService.MasterDatabase");
        public virtual string WebDatabase => Settings.GetSetting("CognitiveService.WebDatabase");
        public virtual ID BigMLSDKId => new ID(Settings.GetSetting(""));
        public virtual ID IBMSDKId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.ID"));
        public virtual ID LexSDKId => new ID(Settings.GetSetting("CognitiveServcie.LexSDK.ID"));
        public virtual ID MSSDKId => new ID(Settings.GetSetting("CognitiveService.MSSDK.ID"));
        public virtual ID NexSDKId => new ID(Settings.GetSetting("CognitiveServcie.NexSDK.ID"));
        public virtual bool CatchAndReleaseExceptions
        {
            get
            {
                var value = Settings.GetSetting("CognitiveService.CatchAndReleaseExceptions");
                bool boolValue;

                return (bool.TryParse(value, out boolValue)) && boolValue;
            }
        }

        public virtual string SitecoreIndexNameFormat => Settings.GetSetting("CognitiveService.SitecoreIndexNameFormat");

        #region BigML

        #endregion

        #region IBMSDK
        public virtual ID IBMSDK_AssistantUsernameFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.AssistantUsernameFieldId"));
        public virtual ID IBMSDK_AssistantPasswordFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.AssistantPasswordFieldId"));
        public virtual ID IBMSDK_AssistantEndpointFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.AssistantEndpointFieldId"));
        public virtual ID IBMSDK_AssistantRetryInSecondsFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.AssistantRetryInSecondsFieldId"));
        public virtual ID IBMSDK_DiscoveryUsernameFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.DiscoveryUsernameFieldId"));
        public virtual ID IBMSDK_DiscoveryPasswordFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.DiscoveryPasswordFieldId"));
        public virtual ID IBMSDK_DiscoveryEndpointFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.DiscoveryEndpointFieldId"));
        public virtual ID IBMSDK_DiscoveryRetryInSecondsFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.DiscoveryRetryInSecondsFieldId"));
        public virtual ID IBMSDK_KnowledgeCatalogEndpointFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.KnowledgeCatalogEndpointFieldId"));
        public virtual ID IBMSDK_KnowledgeCatalogUsernameFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.KnowledgeCatalogUsernameFieldId"));
        public virtual ID IBMSDK_KnowledgeCatalogPasswordFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.KnowledgeCatalogPasswordFieldId"));
        public virtual ID IBMSDK_KnowledgeCatalogRetryInSecondsFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.KnowledgeCatalogRetryInSecondsFieldId"));
        public virtual ID IBMSDK_KnowledgeStudioEndpointFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.KnowledgeStudioEndpointFieldId"));
        public virtual ID IBMSDK_KnowledgeStudioUsernameFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.KnowledgeStudioUsernameFieldId"));
        public virtual ID IBMSDK_KnowledgeStudioPasswordFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.KnowledgeStudioPasswordFieldId"));
        public virtual ID IBMSDK_KnowledgeStudioRetryInSecondsFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.KnowledgeStudioRetryInSecondsFieldId"));
        public virtual ID IBMSDK_LanguageTranslatorUsernameFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.LanguageTranslatorUsernameFieldId"));
        public virtual ID IBMSDK_LanguageTranslatorPasswordFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.LanguageTranslatorPasswordFieldId"));
        public virtual ID IBMSDK_LanguageTranslatorEndpointFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.LanguageTranslatorEndpointFieldId"));
        public virtual ID IBMSDK_LanguageTranslatorRetryInSecondsFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.LanguageTranslatorRetryInSecondsFieldId"));
        public virtual ID IBMSDK_MachineLearningEndpointFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.MachineLearningEndpointFieldId"));
        public virtual ID IBMSDK_MachineLearningUsernameFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.MachineLearningUsernameFieldId"));
        public virtual ID IBMSDK_MachineLearningPasswordFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.MachineLearningPasswordFieldId"));
        public virtual ID IBMSDK_MachineLearningRetryInSecondsFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.MachineLearningRetryInSecondsFieldId"));
        public virtual ID IBMSDK_NaturalLanguageClassifierFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.NaturalLanguageClassifierFieldId"));
        public virtual ID IBMSDK_NaturalLanguageClassifierEndpointFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.NaturalLanguageClassifierEndpointFieldId"));
        public virtual ID IBMSDK_NaturalLanguageClassifierUsernameFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.NaturalLanguageClassifierUsernameFieldId"));
        public virtual ID IBMSDK_NaturalLanguageClassifierPasswordFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.NaturalLanguageClassifierPasswordFieldId"));
        public virtual ID IBMSDK_NaturalLanguageClassifierRetryInSecondsFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.NaturalLanguageClassifierRetryInSecondsFieldId"));
        public virtual ID IBMSDK_NaturalLanguageUnderstandingEndpointFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.NaturalLanguageUnderstandingEndpointFieldId"));
        public virtual ID IBMSDK_NaturalLanguageUnderstandingUsernameFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.NaturalLanguageUnderstandingUsernameFieldId"));
        public virtual ID IBMSDK_NaturalLanguageUnderstandingPasswordFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.NaturalLanguageUnderstandingPasswordFieldId"));
        public virtual ID IBMSDK_NaturalLanguageUnderstandingRetryInSecondsFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.NaturalLanguageUnderstandingRetryInSecondsFieldId"));
        public virtual ID IBMSDK_PersonalityInsightsUsernameFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.PersonalityInsightsUsernameFieldId"));
        public virtual ID IBMSDK_PersonalityInsightsPasswordFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.PersonalityInsightsPasswordFieldId"));
        public virtual ID IBMSDK_PersonalityInsightsEndpointFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.PersonalityInsightsEndpointFieldId"));
        public virtual ID IBMSDK_PersonalityInsightsRetryInSecondsFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.PersonalityInsightsRetryInSecondsFieldId"));
        public virtual ID IBMSDK_SpeechToTextUsernameFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.SpeechToTextUsernameFieldId"));
        public virtual ID IBMSDK_SpeechToTextPasswordFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.SpeechToTextPasswordFieldId"));
        public virtual ID IBMSDK_SpeechToTextEndpointFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.SpeechToTextEndpointFieldId"));
        public virtual ID IBMSDK_SpeechToTextRetryInSecondsFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.SpeechToTextRetryInSecondsFieldId"));
        public virtual ID IBMSDK_TextToSpeechUsernameFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.TextToSpeechUsernameFieldId"));
        public virtual ID IBMSDK_TextToSpeechPasswordFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.TextToSpeechPasswordFieldId"));
        public virtual ID IBMSDK_TextToSpeechEndpointFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.TextToSpeechEndpointFieldId"));
        public virtual ID IBMSDK_TextToSpeechRetryInSecondsFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.TextToSpeechRetryInSecondsFieldId"));
        public virtual ID IBMSDK_ToneAnalyzerUsernameFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.ToneAnalyzerUsernameFieldId"));
        public virtual ID IBMSDK_ToneAnalyzerPasswordFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.ToneAnalyzerPasswordFieldId"));
        public virtual ID IBMSDK_ToneAnalyzerEndpointFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.ToneAnalyzerEndpointFieldId"));
        public virtual ID IBMSDK_ToneAnalyzerRetryInSecondsFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.ToneAnalyzerRetryInSecondsFieldId"));
        public virtual ID IBMSDK_VisualRecognitionFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.VisualRecognitionFieldId"));
        public virtual ID IBMSDK_VisualRecognitionEndpointFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.VisualRecognitionEndpointFieldId"));
        public virtual ID IBMSDK_VisualRecognitionRetryInSecondsFieldId => new ID(Settings.GetSetting("CognitiveService.IBMSDK.VisualRecognitionRetryInSecondsFieldId"));
        #endregion

        #region LexSDK
        public virtual ID LexSDK_ApiVersionFieldId => new ID(Settings.GetSetting("CognitiveService.LexSDK.ApiVersionFieldId"));
        public virtual ID LexSDK_AppNameFieldId => new ID(Settings.GetSetting("CognitiveService.LexSDK.AppNameFieldId"));
        public virtual ID LexSDK_AuthHostFieldId => new ID(Settings.GetSetting("CognitiveService.LexSDK.AuthHostFieldId"));
        public virtual ID LexSDK_AuthAppKeyFieldId => new ID(Settings.GetSetting("CognitiveService.LexSDK.AuthAppKeyFieldId"));
        public virtual ID LexSDK_ConsumerKeyFieldId => new ID(Settings.GetSetting("CognitiveService.LexSDK.ConsumerKeyFieldId"));
        public virtual ID LexSDK_ConsumerSecretFieldId => new ID(Settings.GetSetting("CognitiveService.LexSDK.ConsumerSecretFieldId"));
        public virtual ID LexSDK_FormatFieldId => new ID(Settings.GetSetting("CognitiveService.LexSDK.FormatFieldId"));
        public virtual ID LexSDK_HostFieldId => new ID(Settings.GetSetting("CognitiveService.LexSDK.HostFieldId"));
        public virtual ID LexSDK_PasswordFieldId => new ID(Settings.GetSetting("CognitiveService.LexSDK.PasswordFieldId"));
        public virtual ID LexSDK_UseCompressionFieldId => new ID(Settings.GetSetting("CognitiveService.LexSDK.UseCompressionFieldId"));
        public virtual ID LexSDK_UsernameFieldId => new ID(Settings.GetSetting("CognitiveService.LexSDK.UsernameFieldId"));
        public virtual ID LexSDK_WrapperNameFieldId => new ID(Settings.GetSetting("CognitiveService.LexSDK.WrapperNameFieldId"));
        #endregion

        #region MSSDK
        public virtual ID MSSDK_AcademicFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.AcademicFieldId"));
        public virtual ID MSSDK_AcademicEndpointFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.AcademicEndpointFieldId"));
        public virtual ID MSSDK_AcademicRetryInSecondsFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.AcademicRetryInSecondsFieldId"));
        public virtual ID MSSDK_BingAutosuggestFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.BingAutosuggestFieldId"));
        public virtual ID MSSDK_BingAutosuggestEndpointFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.BingAutosuggestEndpointFieldId"));
        public virtual ID MSSDK_BingAutosuggestRetryInSecondsFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.BingAutosuggestRetryInSecondsFieldId"));
        public virtual ID MSSDK_BingSearchFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.BingSearchFieldId"));
        public virtual ID MSSDK_BingSearchEndpointFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.BingSearchEndpointFieldId"));
        public virtual ID MSSDK_BingSearchRetryInSecondsFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.BingSearchRetryInSecondsFieldId"));
        public virtual ID MSSDK_BingSpellCheckFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.BingSpellCheckFieldId"));
        public virtual ID MSSDK_BingSpellCheckEndpointFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.BingSpellCheckEndpointFieldId"));
        public virtual ID MSSDK_BingSpellCheckRetryInSecondsFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.BingSpellCheckRetryInSecondsFieldId"));
        public virtual ID MSSDK_ComputerVisionFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.ComputerVisionFieldId"));
        public virtual ID MSSDK_ComputerVisionEndpointFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.ComputerVisionEndpointFieldId"));
        public virtual ID MSSDK_ComputerVisionRetryInSecondsFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.ComputerVisionRetryInSecondsFieldId"));
        public virtual ID MSSDK_ContentModeratorFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.ContentModeratorFieldId"));
        public virtual ID MSSDK_ContentModeratorClientIdFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.ContentModeratorClientIdFieldId"));
        public virtual ID MSSDK_ContentModeratorPrivateKeyFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.ContentModeratorPrivateKeyFieldId"));
        public virtual ID MSSDK_ContentModeratorEndpointFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.ContentModeratorEndpointFieldId"));
        public virtual ID MSSDK_ContentModeratorRetryInSecondsFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.ContentModeratorRetryInSecondsFieldId"));
        public virtual ID MSSDK_EntityLinkingFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.EntityLinkingFieldId"));
        public virtual ID MSSDK_EntityLinkingEndpointFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.EntityLinkingEndpointFieldId"));
        public virtual ID MSSDK_EntityLinkingRetryInSecondsFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.EntityLinkingRetryInSecondsFieldId"));
        public virtual ID MSSDK_FaceFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.FaceFieldId"));
        public virtual ID MSSDK_FaceEndpointFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.FaceEndpointFieldId"));
        public virtual ID MSSDK_FaceRetryInSecondsFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.FaceRetryInSecondsFieldId"));
        public virtual ID MSSDK_LuisFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.LuisFieldId"));
        public virtual ID MSSDK_LuisAuthoringFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.LuisAuthoringFieldId"));
        public virtual ID MSSDK_LuisEndpointFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.LuisEndpointFieldId"));
        public virtual ID MSSDK_LuisRetryInSecondsFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.LuisRetryInSecondsFieldId"));
        public virtual ID MSSDK_LuisIntentConfidenceThresholdFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.LuisIntentConfidenceThresholdFieldId"));
        public virtual ID MSSDK_QnAFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.QnAFieldId"));
        public virtual ID MSSDK_QnAEndpointFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.QnAEndpointFieldId"));
        public virtual ID MSSDK_QnARetryInSecondsFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.QnARetryInSecondsFieldId"));
        public virtual ID MSSDK_RecommendationsFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.RecommendationsFieldId"));
        public virtual ID MSSDK_RecommendationsEndpointFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.RecommendationsEndpointFieldId"));
        public virtual ID MSSDK_RecommendationsRetryInSecondsFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.RecommendationsRetryInSecondsFieldId"));
        public virtual ID MSSDK_SpeakerRecognitionFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.SpeakerRecognitionFieldId"));
        public virtual ID MSSDK_SpeakerRecognitionEndpointFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.SpeakerRecognitionEndpointFieldId"));
        public virtual ID MSSDK_SpeakerRecognitionRetryInSecondsFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.SpeakerRecognitionRetryInSecondsFieldId"));
        public virtual ID MSSDK_SpeechFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.SpeechFieldId"));
        public virtual ID MSSDK_SpeechEndpointFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.SpeechEndpointFieldId"));
        public virtual ID MSSDK_SpeechTokenEndpointFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.SpeechTokenEndpointFieldId"));
        public virtual ID MSSDK_SpeechRetryInSecondsFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.SpeechRetryInSecondsFieldId"));
        public virtual ID MSSDK_TextAnalyticsFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.TextAnalyticsFieldId"));
        public virtual ID MSSDK_TextAnalyticsEndpointFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.TextAnalyticsEndpointFieldId"));
        public virtual ID MSSDK_TextAnalyticsRetryInSecondsFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.TextAnalyticsRetryInSecondsFieldId"));
        public virtual ID MSSDK_VideoFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.VideoFieldId"));
        public virtual ID MSSDK_VideoEndpointFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.VideoEndpointFieldId"));
        public virtual ID MSSDK_VideoRetryInSecondsFieldId => new ID(Settings.GetSetting("CognitiveService.MSSDK.VideoRetryInSecondsFieldId"));
        #endregion

        #region NexSDK
        public virtual ID NexSDK_ApiTokenFieldId => new ID(Settings.GetSetting("CognitiveService.NexSDK.ApiTokenFieldId"));
        public virtual ID NexSDK_ClientVersionFieldId => new ID(Settings.GetSetting("CognitiveService.NexSDK.ClientVersionFieldId"));
        public virtual ID NexSDK_EndpointFieldId => new ID(Settings.GetSetting("CognitiveService.NexSDK.EndpointFieldId"));
        #endregion
    }
}