using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using SitecoreCognitiveServices.Foundation.LexSDK;
using SitecoreCognitiveServices.Foundation.LexSDK.Account;
using SitecoreCognitiveServices.Foundation.LexSDK.Blacklist;
using SitecoreCognitiveServices.Foundation.LexSDK.Category;
using SitecoreCognitiveServices.Foundation.LexSDK.Collection;
using SitecoreCognitiveServices.Foundation.LexSDK.Configuration;
using SitecoreCognitiveServices.Foundation.LexSDK.Document;
using SitecoreCognitiveServices.Foundation.LexSDK.Entity;
using SitecoreCognitiveServices.Foundation.LexSDK.Http;
using SitecoreCognitiveServices.Foundation.LexSDK.Query;
using SitecoreCognitiveServices.Foundation.LexSDK.SentimentPhrase;
using SitecoreCognitiveServices.Foundation.LexSDK.Taxonomy;
using SitecoreCognitiveServices.Foundation.LexSDK.Template;
using SitecoreCognitiveServices.Foundation.SCSDK.Keys;
using SitecoreCognitiveServices.Foundation.SCSDK.Services.LexSDK;
using AccountService = SitecoreCognitiveServices.Foundation.SCSDK.Services.LexSDK.AccountService;
using IAccountService = SitecoreCognitiveServices.Foundation.SCSDK.Services.LexSDK.IAccountService;

namespace SitecoreCognitiveServices.Foundation.SCSDK
{
    public class LexSDKIocConfig : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            //system and keys
            serviceCollection.AddTransient<ILexalyticsApiKeys, LexalyticsApiKeys>();
            serviceCollection.AddTransient<ILexalyticsRepositoryClient, LexalyticsRepositoryClient>();
            
            //lexsdk repositories
            serviceCollection.AddTransient<IAccountRepository, AccountRepository>();
            serviceCollection.AddTransient<IBlacklistRepository, BlacklistRepository>();
            serviceCollection.AddTransient<ICategoryRepository, CategoryRepository>();
            serviceCollection.AddTransient<ICollectionRepository, CollectionRepository>();
            serviceCollection.AddTransient<IConfigurationRepository, ConfigurationRepository>();
            serviceCollection.AddTransient<IDocumentRepository, DocumentRepository>();
            serviceCollection.AddTransient<IEntityRepository, EntityRepository>();
            serviceCollection.AddTransient<IQueryRepository, QueryRepository>();
            serviceCollection.AddTransient<ISentimentPhraseRepository, SentimentPhraseRepository>();
            serviceCollection.AddTransient<ITaxonomyRepository, TaxonomyRepository>();
            serviceCollection.AddTransient<ITemplateRepository, TemplateRepository>();

            //lexsdk services
            serviceCollection.AddTransient<IAccountService, AccountService>();
            serviceCollection.AddTransient<IBlacklistService, BlacklistService>();
            serviceCollection.AddTransient<ICategoryService, CategoryService>();
            serviceCollection.AddTransient<ICollectionService, CollectionService>();
            serviceCollection.AddTransient<IConfigurationService, ConfigurationService>();
            serviceCollection.AddTransient<IDocumentService, DocumentService>();
            serviceCollection.AddTransient<IEntityService, EntityService>();
            serviceCollection.AddTransient<IQueryService, QueryService>();
            serviceCollection.AddTransient<ISentimentPhraseService, SentimentPhraseService>();
            serviceCollection.AddTransient<ITaxonomyService, TaxonomyService>();
            serviceCollection.AddTransient<ITemplateService, TemplateService>();
        }
    }
}