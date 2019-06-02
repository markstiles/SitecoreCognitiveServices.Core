using System;
using SitecoreCognitiveServices.Foundation.MSSDK;
using Sitecore.Configuration;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Keys
{
    public class MicrosoftCognitiveServicesApiKeys : IMicrosoftCognitiveServicesApiKeys
    {
        #region Constructor 

        protected readonly ISitecoreDataWrapper DataWrapper;
        protected readonly ISCSDKSettings Settings;

        protected Item KeyItem;

        public MicrosoftCognitiveServicesApiKeys(
            ISitecoreDataWrapper dataWrapper,
            ISCSDKSettings settings)
        {
            DataWrapper = dataWrapper;
            Settings = settings;

            KeyItem = DataWrapper?
                .GetDatabase(Settings.MasterDatabase)
                .GetItem(Settings.MSSDKId);
        }

        #endregion Constructor 

        public virtual string Academic => KeyItem[Settings.MSSDK_AcademicFieldId];
        public virtual string AcademicEndpoint => KeyItem[Settings.MSSDK_AcademicEndpointFieldId];
        public virtual int AcademicRetryInSeconds => int.Parse(KeyItem[Settings.MSSDK_AcademicRetryInSecondsFieldId]);
        public virtual string BingSpellCheck => KeyItem[Settings.MSSDK_BingSpellCheckFieldId];
        public virtual string BingSpellCheckEndpoint => KeyItem[Settings.MSSDK_BingSpellCheckEndpointFieldId];
        public virtual int BingSpellCheckRetryInSeconds => int.Parse(KeyItem[Settings.MSSDK_BingSpellCheckRetryInSecondsFieldId]);
        public virtual string BingAutosuggest => KeyItem[Settings.MSSDK_BingAutosuggestFieldId];
        public virtual string BingAutosuggestEndpoint => KeyItem[Settings.MSSDK_BingAutosuggestEndpointFieldId];
        public virtual int BingAutosuggestRetryInSeconds => int.Parse(KeyItem[Settings.MSSDK_BingAutosuggestRetryInSecondsFieldId]);
        public virtual string BingSearch => KeyItem[Settings.MSSDK_BingSearchFieldId];
        public virtual string BingSearchEndpoint => KeyItem[Settings.MSSDK_BingSearchEndpointFieldId];
        public virtual int BingSearchRetryInSeconds => int.Parse(KeyItem[Settings.MSSDK_BingSearchRetryInSecondsFieldId]);
        public virtual string ComputerVision => KeyItem[Settings.MSSDK_ComputerVisionFieldId];
        public virtual string ComputerVisionEndpoint => KeyItem[Settings.MSSDK_ComputerVisionEndpointFieldId];
        public virtual int ComputerVisionRetryInSeconds => int.Parse(KeyItem[Settings.MSSDK_ComputerVisionRetryInSecondsFieldId]);
        public virtual string ContentModerator => KeyItem[Settings.MSSDK_ContentModeratorFieldId];
        public virtual string ContentModeratorClientId => KeyItem[Settings.MSSDK_ContentModeratorClientIdFieldId];
        public virtual string ContentModeratorPrivateKey => KeyItem[Settings.MSSDK_ContentModeratorPrivateKeyFieldId];
        public virtual string ContentModeratorEndpoint => KeyItem[Settings.MSSDK_ContentModeratorEndpointFieldId];
        public virtual int ContentModeratorRetryInSeconds => int.Parse(KeyItem[Settings.MSSDK_ContentModeratorRetryInSecondsFieldId]);
        public virtual string EntityLinking => KeyItem[Settings.MSSDK_EntityLinkingFieldId];
        public virtual string EntityLinkingEndpoint => KeyItem[Settings.MSSDK_EntityLinkingEndpointFieldId];
        public virtual int EntityLinkingRetryInSeconds => int.Parse(KeyItem[Settings.MSSDK_EntityLinkingRetryInSecondsFieldId]);
        public virtual string Face => KeyItem[Settings.MSSDK_FaceFieldId];
        public virtual string FaceEndpoint => KeyItem[Settings.MSSDK_FaceEndpointFieldId];
        public virtual int FaceRetryInSeconds => int.Parse(KeyItem[Settings.MSSDK_FaceRetryInSecondsFieldId]);
        public virtual string Luis => KeyItem[Settings.MSSDK_LuisFieldId];
        public virtual string LuisEndpoint => KeyItem[Settings.MSSDK_LuisEndpointFieldId];
        public virtual int LuisRetryInSeconds => int.Parse(KeyItem[Settings.MSSDK_LuisRetryInSecondsFieldId]);
        public virtual float LuisIntentConfidenceThreshold
        {
            get
            {
                float defaultValue = 0.4f;
                Field f = KeyItem?.Fields[Settings.MSSDK_LuisIntentConfidenceThresholdFieldId];
                if (f == null)
                    return defaultValue;

                float returnObj;
                return (float.TryParse(f.Value, out returnObj))
                    ? returnObj
                    : defaultValue;
            }
        }
        public virtual string QnA => KeyItem[Settings.MSSDK_QnAFieldId];
        public virtual string QnAEndpoint => KeyItem[Settings.MSSDK_QnAEndpointFieldId];
        public virtual int QnARetryInSeconds => int.Parse(KeyItem[Settings.MSSDK_QnARetryInSecondsFieldId]);
        public virtual string Recommendations => KeyItem[Settings.MSSDK_RecommendationsFieldId];
        public virtual string RecommendationsEndpoint => KeyItem[Settings.MSSDK_RecommendationsEndpointFieldId];
        public virtual int RecommendationsRetryInSeconds => int.Parse(KeyItem[Settings.MSSDK_RecommendationsRetryInSecondsFieldId]);
        public virtual string SpeakerRecognition => KeyItem[Settings.MSSDK_SpeakerRecognitionFieldId];
        public virtual string SpeakerRecognitionEndpoint => KeyItem[Settings.MSSDK_SpeakerRecognitionEndpointFieldId];
        public virtual int SpeakerRecognitionRetryInSeconds => int.Parse(KeyItem[Settings.MSSDK_SpeakerRecognitionRetryInSecondsFieldId]);
        public virtual string Speech => KeyItem[Settings.MSSDK_SpeechFieldId];
        public virtual string SpeechEndpoint => KeyItem[Settings.MSSDK_SpeechEndpointFieldId];
        public virtual string SpeechTokenEndpoint => KeyItem[Settings.MSSDK_SpeechTokenEndpointFieldId];
        public virtual int SpeechRetryInSeconds => int.Parse(KeyItem[Settings.MSSDK_SpeechRetryInSecondsFieldId]);
        public virtual string TextAnalytics => KeyItem[Settings.MSSDK_TextAnalyticsFieldId];
        public virtual string TextAnalyticsEndpoint => KeyItem[Settings.MSSDK_TextAnalyticsEndpointFieldId];
        public virtual int TextAnalyticsRetryInSeconds => int.Parse(KeyItem[Settings.MSSDK_TextAnalyticsRetryInSecondsFieldId]);
        public virtual string Video => KeyItem[Settings.MSSDK_VideoFieldId];
        public virtual string VideoEndpoint => KeyItem[Settings.MSSDK_VideoEndpointFieldId];
        public virtual int VideoRetryInSeconds => int.Parse(KeyItem[Settings.MSSDK_VideoRetryInSecondsFieldId]);
    }
}
