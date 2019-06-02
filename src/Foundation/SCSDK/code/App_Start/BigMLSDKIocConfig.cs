using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using SitecoreCognitiveServices.Foundation.BigMLSDK;
using SitecoreCognitiveServices.Foundation.BigMLSDK.Http;
using SitecoreCognitiveServices.Foundation.BigMLSDK.Projects;
using SitecoreCognitiveServices.Foundation.BigMLSDK.Sources;
using SitecoreCognitiveServices.Foundation.SCSDK.Keys;

namespace SitecoreCognitiveServices.Foundation.SCSDK
{
    public class BigMLSDKIocConfig : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            //system and keys
            serviceCollection.AddTransient<IBigMLApiKeys, BigMLApiKeys>();
            serviceCollection.AddSingleton<IBigMLApiClient, BigMLApiClient>();
            serviceCollection.AddTransient<IBigMLRepositoryClient, BigMLRepositoryClient>();
            
            //ibmsdk repositories
            serviceCollection.AddTransient<ISourceRepository, SourceRepository>();
            serviceCollection.AddTransient<IProjectRepository, ProjectRepository>();

            //ibmsdk services
            //serviceCollection.AddTransient<IAssistantService, AssistantService>();
        }
    }
}