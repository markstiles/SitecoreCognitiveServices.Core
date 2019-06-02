using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;
using SitecoreCognitiveServices.Foundation.IBMSDK;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Keys
{
    public class IBMWatsonApiKeys : IIBMWatsonApiKeys
    {
        #region Constructor 

        protected readonly ISitecoreDataWrapper DataWrapper;
        protected readonly ISCSDKSettings Settings;

        protected Item KeyItem;

        public IBMWatsonApiKeys(
            ISitecoreDataWrapper dataWrapper,
            ISCSDKSettings settings)
        {
            DataWrapper = dataWrapper;
            Settings = settings;

            KeyItem = DataWrapper
                .GetDatabase(Settings.MasterDatabase)
                .GetItem(Settings.IBMSDKId);
        }

        #endregion Constructor 

        #region Assistant

        public virtual string AssistantEndpoint => KeyItem[Settings.IBMSDK_AssistantEndpointFieldId];
        public virtual string AssistantUsername => KeyItem[Settings.IBMSDK_AssistantUsernameFieldId];
        public virtual string AssistantPassword => KeyItem[Settings.IBMSDK_AssistantPasswordFieldId];
        public virtual int AssistantRetryInSeconds => int.Parse(KeyItem[Settings.IBMSDK_AssistantRetryInSecondsFieldId]);

        #endregion

        #region Discovery

        public virtual string DiscoveryEndpoint => KeyItem[Settings.IBMSDK_DiscoveryEndpointFieldId];
        public virtual string DiscoveryUsername => KeyItem[Settings.IBMSDK_DiscoveryUsernameFieldId];
        public virtual string DiscoveryPassword => KeyItem[Settings.IBMSDK_DiscoveryPasswordFieldId];
        public virtual int DiscoveryRetryInSeconds => int.Parse(KeyItem[Settings.IBMSDK_DiscoveryRetryInSecondsFieldId]);

        #endregion

        #region Knowledge Catalog

        public virtual string KnowledgeCatalogEndpoint => KeyItem[Settings.IBMSDK_KnowledgeCatalogEndpointFieldId];
        public virtual string KnowledgeCatalogUsername => KeyItem[Settings.IBMSDK_KnowledgeCatalogUsernameFieldId];
        public virtual string KnowledgeCatalogPassword => KeyItem[Settings.IBMSDK_KnowledgeCatalogPasswordFieldId];
        public virtual int KnowledgeCatalogRetryInSeconds => int.Parse(KeyItem[Settings.IBMSDK_KnowledgeCatalogRetryInSecondsFieldId]);

        #endregion

        #region Knowledge Studio

        public virtual string KnowledgeStudioEndpoint => KeyItem[Settings.IBMSDK_KnowledgeStudioEndpointFieldId];
        public virtual string KnowledgeStudioUsername => KeyItem[Settings.IBMSDK_KnowledgeStudioUsernameFieldId];
        public virtual string KnowledgeStudioPassword => KeyItem[Settings.IBMSDK_KnowledgeStudioPasswordFieldId];
        public virtual int KnowledgeStudioRetryInSeconds => int.Parse(KeyItem[Settings.IBMSDK_KnowledgeStudioRetryInSecondsFieldId]);

        #endregion

        #region Language Translator

        public virtual string LanguageTranslatorEndpoint => KeyItem[Settings.IBMSDK_LanguageTranslatorEndpointFieldId];
        public virtual string LanguageTranslatorUsername => KeyItem[Settings.IBMSDK_LanguageTranslatorUsernameFieldId];
        public virtual string LanguageTranslatorPassword => KeyItem[Settings.IBMSDK_LanguageTranslatorPasswordFieldId];
        public virtual int LanguageTranslatorRetryInSeconds => int.Parse(KeyItem[Settings.IBMSDK_LanguageTranslatorRetryInSecondsFieldId]);

        #endregion

        #region Machine Learning

        public virtual string MachineLearningEndpoint => KeyItem[Settings.IBMSDK_MachineLearningEndpointFieldId];
        public virtual string MachineLearningUsername => KeyItem[Settings.IBMSDK_MachineLearningUsernameFieldId];
        public virtual string MachineLearningPassword => KeyItem[Settings.IBMSDK_MachineLearningPasswordFieldId];
        public virtual int MachineLearningRetryInSeconds => int.Parse(KeyItem[Settings.IBMSDK_MachineLearningRetryInSecondsFieldId]);

        #endregion

        #region Natural Language Classifier

        public virtual string NaturalLanguageClassifierEndpoint => KeyItem[Settings.IBMSDK_NaturalLanguageClassifierEndpointFieldId];
        public virtual string NaturalLanguageClassifierUsername => KeyItem[Settings.IBMSDK_NaturalLanguageClassifierUsernameFieldId];
        public virtual string NaturalLanguageClassifierPassword => KeyItem[Settings.IBMSDK_NaturalLanguageClassifierPasswordFieldId];
        public virtual int NaturalLanguageClassifierRetryInSeconds => int.Parse(KeyItem[Settings.IBMSDK_NaturalLanguageClassifierRetryInSecondsFieldId]);

        #endregion

        #region Natural Language Understanding

        public virtual string NaturalLanguageUnderstandingEndpoint => KeyItem[Settings.IBMSDK_NaturalLanguageUnderstandingEndpointFieldId];
        public virtual string NaturalLanguageUnderstandingUsername => KeyItem[Settings.IBMSDK_NaturalLanguageUnderstandingUsernameFieldId];
        public virtual string NaturalLanguageUnderstandingPassword => KeyItem[Settings.IBMSDK_NaturalLanguageUnderstandingPasswordFieldId];
        public virtual int NaturalLanguageUnderstandingRetryInSeconds => int.Parse(KeyItem[Settings.IBMSDK_NaturalLanguageUnderstandingRetryInSecondsFieldId]);

        #endregion

        #region Personality Insights

        public virtual string PersonalityInsightsEndpoint => KeyItem[Settings.IBMSDK_PersonalityInsightsEndpointFieldId];
        public virtual string PersonalityInsightsUsername => KeyItem[Settings.IBMSDK_PersonalityInsightsUsernameFieldId];
        public virtual string PersonalityInsightsPassword => KeyItem[Settings.IBMSDK_PersonalityInsightsPasswordFieldId];
        public virtual int PersonalityInsightsRetryInSeconds => int.Parse(KeyItem[Settings.IBMSDK_PersonalityInsightsRetryInSecondsFieldId]);

        #endregion

        #region Speech To Text

        public virtual string SpeechToTextEndpoint => KeyItem[Settings.IBMSDK_SpeechToTextEndpointFieldId];
        public virtual string SpeechToTextUsername => KeyItem[Settings.IBMSDK_SpeechToTextUsernameFieldId];
        public virtual string SpeechToTextPassword => KeyItem[Settings.IBMSDK_SpeechToTextPasswordFieldId];
        public virtual int SpeechToTextRetryInSeconds => int.Parse(KeyItem[Settings.IBMSDK_SpeechToTextRetryInSecondsFieldId]);

        #endregion

        #region Text To Speech

        public virtual string TextToSpeechEndpoint => KeyItem[Settings.IBMSDK_TextToSpeechEndpointFieldId];
        public virtual string TextToSpeechUsername => KeyItem[Settings.IBMSDK_TextToSpeechUsernameFieldId];
        public virtual string TextToSpeechPassword => KeyItem[Settings.IBMSDK_TextToSpeechPasswordFieldId];
        public virtual int TextToSpeechRetryInSeconds => int.Parse(KeyItem[Settings.IBMSDK_TextToSpeechRetryInSecondsFieldId]);

        #endregion

        #region Tone Analyzer

        public virtual string ToneAnalyzerEndpoint => KeyItem[Settings.IBMSDK_ToneAnalyzerEndpointFieldId];
        public virtual string ToneAnalyzerUsername => KeyItem[Settings.IBMSDK_ToneAnalyzerUsernameFieldId];
        public virtual string ToneAnalyzerPassword => KeyItem[Settings.IBMSDK_ToneAnalyzerPasswordFieldId];
        public virtual int ToneAnalyzerRetryInSeconds => int.Parse(KeyItem[Settings.IBMSDK_ToneAnalyzerRetryInSecondsFieldId]);

        #endregion

        #region Visual Recognition

        public virtual string VisualRecognition => KeyItem[Settings.IBMSDK_VisualRecognitionFieldId];
        public virtual string VisualRecognitionEndpoint => KeyItem[Settings.IBMSDK_VisualRecognitionEndpointFieldId];
        public virtual int VisualRecognitionRetryInSeconds => int.Parse(KeyItem[Settings.IBMSDK_VisualRecognitionRetryInSecondsFieldId]);

        #endregion
    }
}