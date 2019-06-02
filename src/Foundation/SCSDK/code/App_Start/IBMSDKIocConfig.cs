using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using SitecoreCognitiveServices.Foundation.IBMSDK;
using SitecoreCognitiveServices.Foundation.IBMSDK.Assistant;
using SitecoreCognitiveServices.Foundation.IBMSDK.Discovery;
using SitecoreCognitiveServices.Foundation.IBMSDK.Http;
using SitecoreCognitiveServices.Foundation.IBMSDK.LanguageTranslator;
using SitecoreCognitiveServices.Foundation.IBMSDK.NaturalLanguageClassifier;
using SitecoreCognitiveServices.Foundation.IBMSDK.PersonalityInsights;
using SitecoreCognitiveServices.Foundation.IBMSDK.SpeechToText;
using SitecoreCognitiveServices.Foundation.IBMSDK.TextToSpeech;
using SitecoreCognitiveServices.Foundation.IBMSDK.ToneAnalyzer;
using SitecoreCognitiveServices.Foundation.IBMSDK.VisualRecognition;
using SitecoreCognitiveServices.Foundation.SCSDK.Keys;
using SitecoreCognitiveServices.Foundation.SCSDK.Services.IBMSDK;

namespace SitecoreCognitiveServices.Foundation.SCSDK
{
    public class IBMSDKIocConfig : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            //system and keys
            serviceCollection.AddTransient<IIBMWatsonApiKeys, IBMWatsonApiKeys>();
            serviceCollection.AddTransient<IIBMWatsonRepositoryClient, IBMWatsonRepositoryClient>();
            
            //ibmsdk repositories
            serviceCollection.AddTransient<IAssistantRepository, AssistantRepository>();
            serviceCollection.AddTransient<IDiscoveryRepository, DiscoveryRepository>();
            serviceCollection.AddTransient<ILanguageTranslatorRepository, LanguageTranslatorRepository>();
            serviceCollection.AddTransient<INaturalLanguageClassifierRepository, NaturalLanguageClassifierRepository>();
            serviceCollection.AddTransient<IPersonalityInsightsRepository, PersonalityInsightsRepository>();
            serviceCollection.AddTransient<ISpeechToTextRepository, SpeechToTextRepository>();
            serviceCollection.AddTransient<ITextToSpeechRepository, TextToSpeechRepository>();
            serviceCollection.AddTransient<IToneAnalyzerRepository, ToneAnalyzerRepository>();
            serviceCollection.AddTransient<IVisualRecognitionRepository, VisualRecognitionRepository>();

            //ibmsdk services
            serviceCollection.AddTransient<IAssistantService, AssistantService>();
            serviceCollection.AddTransient<IDiscoveryService, DiscoveryService>();
            serviceCollection.AddTransient<ILanguageTranslatorService, LanguageTranslatorService>();
            serviceCollection.AddTransient<INaturalLanguageClassifierService, NaturalLanguageClassifierService>();
            serviceCollection.AddTransient<IPersonalityInsightsService, PersonalityInsightsService>();
            serviceCollection.AddTransient<ISpeechToTextService, SpeechToTextService>();
            serviceCollection.AddTransient<ITextToSpeechService, TextToSpeechService>();
            serviceCollection.AddTransient<IToneAnalyzerService, ToneAnalyzerService>();
            serviceCollection.AddTransient<IVisualRecognitionService, VisualRecognitionService>();
        }
    }
}