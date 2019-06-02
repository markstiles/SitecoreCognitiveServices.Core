using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Foundation.SCSDK
{
    public class SCSDKIocConfig : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            //system and keys
            serviceCollection.AddTransient<ISCSDKSettings, SCSDKSettings>();
            
            //sitecore wrappers
            serviceCollection.AddTransient<ISitecoreDataWrapper, SitecoreDataWrapper>();
            serviceCollection.AddTransient<IWebUtilWrapper, WebUtilWrapper>();
            serviceCollection.AddTransient<ILogWrapper, LogWrapper>();
            serviceCollection.AddTransient<ITextTranslatorWrapper, TextTranslatorWrapper>();
            serviceCollection.AddTransient<IPublishWrapper, PublishWrapper>();
            serviceCollection.AddTransient<IAuthenticationWrapper, AuthenticationWrapper>();
            serviceCollection.AddTransient<IContentSearchWrapper, ContentSearchWrapper>();
            serviceCollection.AddTransient<IContextItemsWrapper, ContextItemsWrapper>();
            serviceCollection.AddTransient<IMediaWrapper, MediaWrapper>();
        }
    }
}