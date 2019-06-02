using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using SitecoreCognitiveServices.Foundation.NexSDK;
using SitecoreCognitiveServices.Foundation.NexSDK.Account;
using SitecoreCognitiveServices.Foundation.NexSDK.Contest;
using SitecoreCognitiveServices.Foundation.NexSDK.DataSet;
using SitecoreCognitiveServices.Foundation.NexSDK.Http;
using SitecoreCognitiveServices.Foundation.NexSDK.Import;
using SitecoreCognitiveServices.Foundation.NexSDK.Model;
using SitecoreCognitiveServices.Foundation.NexSDK.Session;
using SitecoreCognitiveServices.Foundation.NexSDK.View;
using SitecoreCognitiveServices.Foundation.NexSDK.Vocabulary;
using SitecoreCognitiveServices.Foundation.SCSDK.Keys;
using SitecoreCognitiveServices.Foundation.SCSDK.Services.NexSDK;

namespace SitecoreCognitiveServices.Foundation.SCSDK
{
    public class NexSDKIocConfig : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            //system and keys
            serviceCollection.AddTransient<INexosisClient, NexosisClient>();
            serviceCollection.AddTransient<INexosisApiKeys, NexosisApiKeys>();

            //nexsdk repositories
            serviceCollection.AddTransient<IAccountRepository, AccountRepository>();
            serviceCollection.AddTransient<IContestRepository, ContestRepository>();
            serviceCollection.AddTransient<IDataSetRepository, DataSetRepository>();
            serviceCollection.AddTransient<IImportRepository, ImportRepository>();
            serviceCollection.AddTransient<IModelRepository, ModelRepository>();
            serviceCollection.AddTransient<ISessionRepository, SessionRepository>();
            serviceCollection.AddTransient<IViewRepository, ViewRepository>();
            serviceCollection.AddTransient<IVocabularyRepository, VocabularyRepository>();

            //nexsdk services
            serviceCollection.AddTransient<IAccountService, AccountService>();
            serviceCollection.AddTransient<IContestService, ContestService>();
            serviceCollection.AddTransient<IDataSetService, DataSetService>();
            serviceCollection.AddTransient<IImportService, ImportService>();
            serviceCollection.AddTransient<IModelService, ModelService>();
            serviceCollection.AddTransient<ISessionService, SessionService>();
            serviceCollection.AddTransient<IViewService, ViewService>();
            serviceCollection.AddTransient<IVocabularyService, VocabularyService>();
        }
    }
}