using Microsoft.Extensions.DependencyInjection;
using SitecoreCognitiveServices.Foundation.MSSDK;
using SitecoreCognitiveServices.Foundation.MSSDK.CSV;
using Sitecore.DependencyInjection;
using SitecoreCognitiveServices.Foundation.MSSDK.Bing;
using SitecoreCognitiveServices.Foundation.MSSDK.Http;
using SitecoreCognitiveServices.Foundation.MSSDK.Knowledge;
using SitecoreCognitiveServices.Foundation.MSSDK.Language;
using SitecoreCognitiveServices.Foundation.MSSDK.Speech;
using SitecoreCognitiveServices.Foundation.MSSDK.Vision;
using SitecoreCognitiveServices.Foundation.SCSDK.Keys;
using SitecoreCognitiveServices.Foundation.SCSDK.RetryPolicies;
using SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Knowledge;
using SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language;
using SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Speech;
using SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Vision;
using SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Bing;
using SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language.Factories;
using SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language.Models;
using SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language.Providers;

namespace SitecoreCognitiveServices.Foundation.SCSDK
{
    public class MSSDKIocConfig : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            //system and keys
            serviceCollection.AddTransient<IMicrosoftCognitiveServicesApiKeys, MicrosoftCognitiveServicesApiKeys>();
            serviceCollection.AddTransient<IMicrosoftCognitiveServicesRepositoryClient, MicrosoftCognitiveServicesRepositoryClient>();
            serviceCollection.AddTransient<ICSVParser, CSVParser>();
            serviceCollection.AddTransient<IMSSDKPolicyService, MSSDKPolicyService>();

            //mssdk repositories
            serviceCollection.AddTransient<IEntityLinkingRepository, EntityLinkingRepository>();
            serviceCollection.AddTransient<IFaceRepository, FaceRepository>();
            serviceCollection.AddTransient<ITextAnalyticsRepository, TextAnalyticsRepository>();
            serviceCollection.AddTransient<ISpeakerIdentificationRepository, SpeakerIdentificationRepository>();
            serviceCollection.AddTransient<ISpeakerVerificationRepository, SpeakerVerificationRepository>();
            serviceCollection.AddTransient<IVideoRepository, VideoRepository>();
            serviceCollection.AddTransient<IComputerVisionRepository, ComputerComputerVisionRepository>();
            serviceCollection.AddTransient<IAutoSuggestRepository, AutoSuggestRepository>();
            serviceCollection.AddTransient<IImageSearchRepository, ImageSearchRepository>();
            serviceCollection.AddTransient<ISpellCheckRepository, SpellCheckRepository>();
            serviceCollection.AddTransient<IWebSearchRepository, WebSearchRepository>();
            serviceCollection.AddTransient<INewsSearchRepository, NewsSearchRepository>();
            serviceCollection.AddTransient<IVideoSearchRepository, VideoSearchRepository>();
            serviceCollection.AddTransient<IAcademicSearchRepository, AcademicSearchRepository>();
            serviceCollection.AddTransient<IRecommendationsRepository, RecommendationsRepository>();
            serviceCollection.AddTransient<IContentModeratorRepository, ContentModeratorRepository>();
            serviceCollection.AddTransient<ILuisRepository, LuisRepository>();
            serviceCollection.AddTransient<ISpeechRepository, SpeechRepository>();
            serviceCollection.AddTransient<IQnAMakerRepository, QnAMakerRepository>();
            
            //mssdk services
            serviceCollection.AddTransient<IEntityLinkingService, EntityLinkingService>();
            serviceCollection.AddTransient<IFaceService, FaceService>();
            serviceCollection.AddTransient<ITextAnalyticsService, TextAnalyticsService>();
            serviceCollection.AddTransient<ISpeakerIdentificationService, SpeakerIdentificationService>();
            serviceCollection.AddTransient<ISpeakerVerificationService, SpeakerVerificationService>();
            serviceCollection.AddTransient<IVideoService, VideoService>();
            serviceCollection.AddTransient<IComputerVisionService, ComputerVisionService>();
            serviceCollection.AddTransient<IAutoSuggestService, AutoSuggestService>();
            serviceCollection.AddTransient<IImageSearchService, ImageSearchService>();
            serviceCollection.AddTransient<ISpellCheckService, SpellCheckService>();
            serviceCollection.AddTransient<IWebSearchService, WebSearchService>();
            serviceCollection.AddTransient<INewsSearchService, NewsSearchService>();
            serviceCollection.AddTransient<IVideoSearchService, VideoSearchService>();
            serviceCollection.AddTransient<IAcademicSearchService, AcademicSearchService>();
            serviceCollection.AddTransient<IRecommendationsService, RecommendationsService>();
            serviceCollection.AddTransient<IContentModeratorService, ContentModeratorService>();
            serviceCollection.AddTransient<ILuisService, LuisService>();
            serviceCollection.AddTransient<ISpeechService, SpeechService>();
            serviceCollection.AddTransient<IQnAMakerService, QnAMakerService>();

            //intent provider
            serviceCollection.AddScoped<IIntentProvider, IntentProvider>();

            //conversation
            serviceCollection.AddTransient<IConversation, Conversation>();
            serviceCollection.AddTransient<IConversationFactory, ConversationFactory>();
            serviceCollection.AddTransient<IConversationHistory, ConversationHistory>();
            serviceCollection.AddTransient<IConversationContext, ConversationContext>();
            serviceCollection.AddTransient<IConversationContextFactory, ConversationContextFactory>();
            serviceCollection.AddTransient<ILuisConversationService, LuisConversationService>();
            serviceCollection.AddTransient<IIntentInputFactory, IntentInputFactory>();
            serviceCollection.AddTransient<IParameterResultFactory, ParameterResultFactory>();
            serviceCollection.AddTransient<IConversationResponseFactory, ConversationResponseFactory>();
        }
    }
}