using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Tests
{
    public class BaseTestFixture
    {
        public IIBMWatsonApiKeys GetKeys()
        {
            IIBMWatsonApiKeys _keys;

            _keys = Substitute.For<IIBMWatsonApiKeys>();

            _keys.AssistantUsername.Returns(ConfigurationManager.AppSettings.Get("IBMSDK.AssistantUsername"));
            _keys.AssistantPassword.Returns(ConfigurationManager.AppSettings.Get("IBMSDK.AssistantPassword"));
            _keys.AssistantEndpoint.Returns(ConfigurationManager.AppSettings.Get("IBMSDK.AssistantEndpoint"));
            _keys.AssistantRetryInSeconds.Returns(Int32.Parse(ConfigurationManager.AppSettings.Get("IBMSDK.AssistantRetryInSeconds")));

            _keys.DiscoveryUsername.Returns(ConfigurationManager.AppSettings.Get("IBMSDK.DiscoveryUsername"));
            _keys.DiscoveryPassword.Returns(ConfigurationManager.AppSettings.Get("IBMSDK.DiscoveryPassword"));
            _keys.DiscoveryEndpoint.Returns(ConfigurationManager.AppSettings.Get("IBMSDK.DiscoveryEndpoint"));
            _keys.DiscoveryRetryInSeconds.Returns(Int32.Parse(ConfigurationManager.AppSettings.Get("IBMSDK.DiscoveryRetryInSeconds")));

            _keys.LanguageTranslatorUsername.Returns(ConfigurationManager.AppSettings.Get("IBMSDK.LanguageTranslatorUsername"));
            _keys.LanguageTranslatorPassword.Returns(ConfigurationManager.AppSettings.Get("IBMSDK.LanguageTranslatorPassword"));
            _keys.LanguageTranslatorEndpoint.Returns(ConfigurationManager.AppSettings.Get("IBMSDK.LanguageTranslatorEndpoint"));
            _keys.LanguageTranslatorRetryInSeconds.Returns(Int32.Parse(ConfigurationManager.AppSettings.Get("IBMSDK.LanguageTranslatorRetryInSeconds")));

            _keys.NaturalLanguageClassifierEndpoint.Returns(ConfigurationManager.AppSettings.Get("IBMSDK.NaturalLanguageClassifierEndpoint"));
            _keys.NaturalLanguageClassifierUsername.Returns(ConfigurationManager.AppSettings.Get("IBMSDK.NaturalLanguageClassifierUsername"));
            _keys.NaturalLanguageClassifierPassword.Returns(ConfigurationManager.AppSettings.Get("IBMSDK.NaturalLanguageClassifierPassword"));
            _keys.NaturalLanguageClassifierRetryInSeconds.Returns(Int32.Parse(ConfigurationManager.AppSettings.Get("IBMSDK.NaturalLanguageClassifierRetryInSeconds")));

            _keys.PersonalityInsightsUsername.Returns(ConfigurationManager.AppSettings.Get("IBMSDK.PersonalityInsightsUsername"));
            _keys.PersonalityInsightsPassword.Returns(ConfigurationManager.AppSettings.Get("IBMSDK.PersonalityInsightsPassword"));
            _keys.PersonalityInsightsEndpoint.Returns(ConfigurationManager.AppSettings.Get("IBMSDK.PersonalityInsightsEndpoint"));
            _keys.PersonalityInsightsRetryInSeconds.Returns(Int32.Parse(ConfigurationManager.AppSettings.Get("IBMSDK.PersonalityInsightsRetryInSeconds")));

            _keys.SpeechToTextUsername.Returns(ConfigurationManager.AppSettings.Get("IBMSDK.SpeechToTextUsername"));
            _keys.SpeechToTextPassword.Returns(ConfigurationManager.AppSettings.Get("IBMSDK.SpeechToTextPassword"));
            _keys.SpeechToTextEndpoint.Returns(ConfigurationManager.AppSettings.Get("IBMSDK.SpeechToTextEndpoint"));
            _keys.SpeechToTextRetryInSeconds.Returns(Int32.Parse(ConfigurationManager.AppSettings.Get("IBMSDK.SpeechToTextRetryInSeconds")));

            _keys.TextToSpeechUsername.Returns(ConfigurationManager.AppSettings.Get("IBMSDK.TextToSpeechUsername"));
            _keys.TextToSpeechPassword.Returns(ConfigurationManager.AppSettings.Get("IBMSDK.TextToSpeechPassword"));
            _keys.TextToSpeechEndpoint.Returns(ConfigurationManager.AppSettings.Get("IBMSDK.TextToSpeechEndpoint"));
            _keys.TextToSpeechRetryInSeconds.Returns(Int32.Parse(ConfigurationManager.AppSettings.Get("IBMSDK.TextToSpeechRetryInSeconds")));

            _keys.ToneAnalyzerUsername.Returns(ConfigurationManager.AppSettings.Get("IBMSDK.ToneAnalyzerUsername"));
            _keys.ToneAnalyzerPassword.Returns(ConfigurationManager.AppSettings.Get("IBMSDK.ToneAnalyzerPassword"));
            _keys.ToneAnalyzerEndpoint.Returns(ConfigurationManager.AppSettings.Get("IBMSDK.ToneAnalyzerEndpoint"));
            _keys.ToneAnalyzerRetryInSeconds.Returns(Int32.Parse(ConfigurationManager.AppSettings.Get("IBMSDK.ToneAnalyzerRetryInSeconds")));

            _keys.VisualRecognition.Returns(ConfigurationManager.AppSettings.Get("IBMSDK.VisualRecognition"));
            _keys.VisualRecognitionEndpoint.Returns(ConfigurationManager.AppSettings.Get("IBMSDK.VisualRecognitionEndpoint"));
            _keys.VisualRecognitionRetryInSeconds.Returns(Int32.Parse(ConfigurationManager.AppSettings.Get("IBMSDKVisualRecognitionRetryInSeconds")));

            return _keys;
        }
    }
}
