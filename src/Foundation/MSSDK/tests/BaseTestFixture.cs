using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Tests
{
    public class BaseTestFixture
    {
        public IMicrosoftCognitiveServicesApiKeys GetKeys()
        {
            IMicrosoftCognitiveServicesApiKeys _keys = Substitute.For<IMicrosoftCognitiveServicesApiKeys>();
            
            _keys.Academic.Returns(ConfigurationManager.AppSettings.Get("MSSDK.Academic"));
            _keys.AcademicEndpoint.Returns(ConfigurationManager.AppSettings.Get("MSSDK.AcademicEndpoint"));
            _keys.AcademicRetryInSeconds.Returns(Int32.Parse(ConfigurationManager.AppSettings.Get("MSSDK.AcademicRetryInSeconds")));
            _keys.BingAutosuggest.Returns(ConfigurationManager.AppSettings.Get("MSSDK.BingAutosuggest"));
            _keys.BingAutosuggestEndpoint.Returns(ConfigurationManager.AppSettings.Get("MSSDK.BingAutosuggestEndpoint"));
            _keys.BingSearchRetryInSeconds.Returns(Int32.Parse(ConfigurationManager.AppSettings.Get("MSSDK.BingAutosuggestRetryInSeconds")));
            _keys.BingSearch.Returns(ConfigurationManager.AppSettings.Get("MSSDK.BingSearch"));
            _keys.BingSearchEndpoint.Returns(ConfigurationManager.AppSettings.Get("MSSDK.BingSearchEndpoint"));
            _keys.BingSearchRetryInSeconds.Returns(Int32.Parse(ConfigurationManager.AppSettings.Get("MSSDK.BingSearchRetryInSeconds")));
            _keys.BingSpellCheck.Returns(ConfigurationManager.AppSettings.Get("MSSDK.BingSpellCheck"));
            _keys.BingSpellCheckEndpoint.Returns(ConfigurationManager.AppSettings.Get("MSSDK.BingSpellCheckEndpoint"));
            _keys.BingSpellCheckRetryInSeconds.Returns(Int32.Parse(ConfigurationManager.AppSettings.Get("MSSDK.BingSpellCheckRetryInSeconds")));
            _keys.ComputerVision.Returns(ConfigurationManager.AppSettings.Get("MSSDK.ComputerVision"));
            _keys.ComputerVisionEndpoint.Returns(ConfigurationManager.AppSettings.Get("MSSDK.ComputerVisionEndpoint"));
            _keys.ComputerVisionRetryInSeconds.Returns(Int32.Parse(ConfigurationManager.AppSettings.Get("MSSDK.ComputerVisionRetryInSeconds")));
            _keys.ContentModerator.Returns(ConfigurationManager.AppSettings.Get("MSSDK.ContentModerator"));
            _keys.ContentModeratorClientId.Returns(ConfigurationManager.AppSettings.Get("MSSDK.ContentModeratorClientId"));
            _keys.ContentModeratorPrivateKey.Returns(ConfigurationManager.AppSettings.Get("MSSDK.ContentModeratorPrivateKey"));
            _keys.ContentModeratorEndpoint.Returns(ConfigurationManager.AppSettings.Get("MSSDK.ContentModeratorEndpoint"));
            _keys.ContentModeratorRetryInSeconds.Returns(Int32.Parse(ConfigurationManager.AppSettings.Get("MSSDK.ContentModeratorRetryInSeconds")));
            _keys.EntityLinking.Returns(ConfigurationManager.AppSettings.Get("MSSDK.EntityLinking"));
            _keys.EntityLinkingEndpoint.Returns(ConfigurationManager.AppSettings.Get("MSSDK.EntityLinkingEndpoint"));
            _keys.EntityLinkingRetryInSeconds.Returns(Int32.Parse(ConfigurationManager.AppSettings.Get("MSSDK.EntityLinkingRetryInSeconds")));
            _keys.Face.Returns(ConfigurationManager.AppSettings.Get("MSSDK.Face"));
            _keys.FaceEndpoint.Returns(ConfigurationManager.AppSettings.Get("MSSDK.FaceEndpoint"));
            _keys.FaceRetryInSeconds.Returns(Int32.Parse(ConfigurationManager.AppSettings.Get("MSSDK.FaceRetryInSeconds")));
            _keys.Luis.Returns(ConfigurationManager.AppSettings.Get("MSSDK.Luis"));
            _keys.LuisEndpoint.Returns(ConfigurationManager.AppSettings.Get("MSSDK.LuisEndpoint"));
            _keys.LuisRetryInSeconds.Returns(Int32.Parse(ConfigurationManager.AppSettings.Get("MSSDK.LuisRetryInSeconds")));
            _keys.Personalizer.Returns(ConfigurationManager.AppSettings.Get("MSSDK.Personalizer"));
            _keys.PersonalizerEndpoint.Returns(ConfigurationManager.AppSettings.Get("MSSDK.PersonalizerEndpoint"));
            _keys.PersonalizerRetryInSeconds.Returns(Int32.Parse(ConfigurationManager.AppSettings.Get("MSSDK.PersonalizerRetryInSeconds")));
            _keys.QnA.Returns(ConfigurationManager.AppSettings.Get("MSSDK.QnA"));
            _keys.QnAEndpoint.Returns(ConfigurationManager.AppSettings.Get("MSSDK.QnAEndpoint"));
            _keys.QnARetryInSeconds.Returns(Int32.Parse(ConfigurationManager.AppSettings.Get("MSSDK.QnARetryInSeconds")));
            _keys.SpeakerRecognition.Returns(ConfigurationManager.AppSettings.Get("MSSDK.SpeakerRecognition"));
            _keys.SpeakerRecognitionEndpoint.Returns(ConfigurationManager.AppSettings.Get("MSSDK.SpeakerRecognitionEndpoint"));
            _keys.SpeakerRecognitionRetryInSeconds.Returns(Int32.Parse(ConfigurationManager.AppSettings.Get("MSSDK.SpeakerRecognitionRetryInSeconds")));
            _keys.Speech.Returns(ConfigurationManager.AppSettings.Get("MSSDK.Speech"));
            _keys.SpeechEndpoint.Returns(ConfigurationManager.AppSettings.Get("MSSDK.SpeechEndpoint"));
            _keys.SpeechRetryInSeconds.Returns(Int32.Parse(ConfigurationManager.AppSettings.Get("MSSDK.SpeechRetryInSeconds")));
            _keys.TextAnalytics.Returns(ConfigurationManager.AppSettings.Get("MSSDK.TextAnalytics"));
            _keys.TextAnalyticsEndpoint.Returns(ConfigurationManager.AppSettings.Get("MSSDK.TextAnalyticsEndpoint"));
            _keys.TextAnalyticsRetryInSeconds.Returns(Int32.Parse(ConfigurationManager.AppSettings.Get("MSSDK.TextAnalyticsRetryInSeconds")));
            _keys.Video.Returns(ConfigurationManager.AppSettings.Get("MSSDK.Video"));
            _keys.VideoEndpoint.Returns(ConfigurationManager.AppSettings.Get("MSSDK.VideoEndpoint"));
            _keys.VideoRetryInSeconds.Returns(Int32.Parse(ConfigurationManager.AppSettings.Get("MSSDK.VideoRetryInSeconds")));

            return _keys;
        }
    }
}
