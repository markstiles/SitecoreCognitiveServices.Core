using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models;
using System;
using SitecoreCognitiveServices.Foundation.IBMSDK.Http;
using SitecoreCognitiveServices.Foundation.IBMSDK.Http.Extensions;
using Environment = SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models.Environment;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Discovery
{
    public class DiscoveryRepository : IDiscoveryRepository
    {
        #region Constructor
    
        public static readonly string versionDate = "2017-11-07";

        protected readonly IIBMWatsonApiKeys ApiKeys;
        protected readonly IIBMWatsonRepositoryClient RepositoryClient;

        public DiscoveryRepository(
            IIBMWatsonApiKeys apiKeys,
            IIBMWatsonRepositoryClient repositoryClient)
        {
            ApiKeys = apiKeys;
            RepositoryClient = repositoryClient;
        }

        #endregion
        
        public Environment CreateEnvironment(CreateEnvironmentRequest body)
        {
            if (body == null)
                throw new ArgumentNullException(nameof(body));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'DISCOVERY_VERSION_DATE_2017_11_07'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.DiscoveryUsername, ApiKeys.DiscoveryPassword)
                                .PostAsync($"{ApiKeys.DiscoveryEndpoint}")
                                .WithArgument("version", versionDate)
                                .WithBody<CreateEnvironmentRequest>(body)
                                .As<Environment>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public DeleteEnvironmentResponse DeleteEnvironment(string environmentId)
        {
            if (string.IsNullOrEmpty(environmentId))
                throw new ArgumentNullException(nameof(environmentId));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'DISCOVERY_VERSION_DATE_2017_11_07'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.DiscoveryUsername, ApiKeys.DiscoveryPassword)
                                .DeleteAsync($"{ApiKeys.DiscoveryEndpoint}{environmentId}")
                                .WithArgument("version", versionDate)
                                .As<DeleteEnvironmentResponse>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public Environment GetEnvironment(string environmentId)
        {
            if (string.IsNullOrEmpty(environmentId))
                throw new ArgumentNullException(nameof(environmentId));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'DISCOVERY_VERSION_DATE_2017_11_07'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.DiscoveryUsername, ApiKeys.DiscoveryPassword)
                                .GetAsync($"{ApiKeys.DiscoveryEndpoint}{environmentId}")
                                .WithArgument("version", versionDate)
                                .As<Environment>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public ListEnvironmentsResponse ListEnvironments(string name = null)
        {
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'DISCOVERY_VERSION_DATE_2017_11_07'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.DiscoveryUsername, ApiKeys.DiscoveryPassword)
                                .GetAsync($"{ApiKeys.DiscoveryEndpoint}")
                                .WithArgument("version", versionDate)
                                .WithArgument("name", name)
                                .As<ListEnvironmentsResponse>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public ListCollectionFieldsResponse ListFields(string environmentId, List<string> collectionIds)
        {
            if (string.IsNullOrEmpty(environmentId))
                throw new ArgumentNullException(nameof(environmentId));
            if (collectionIds == null)
                throw new ArgumentNullException(nameof(collectionIds));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'DISCOVERY_VERSION_DATE_2017_11_07'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.DiscoveryUsername, ApiKeys.DiscoveryPassword)
                                .GetAsync($"{ApiKeys.DiscoveryEndpoint}{environmentId}/fields")
                                .WithArgument("version", versionDate)
                                .WithArgument("collection_ids", collectionIds != null && collectionIds.Count > 0 ? string.Join(",", collectionIds.ToArray()) : null)
                                .As<ListCollectionFieldsResponse>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public Environment UpdateEnvironment(string environmentId, UpdateEnvironmentRequest body)
        {
            if (string.IsNullOrEmpty(environmentId))
                throw new ArgumentNullException(nameof(environmentId));
            if (body == null)
                throw new ArgumentNullException(nameof(body));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'DISCOVERY_VERSION_DATE_2017_11_07'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.DiscoveryUsername, ApiKeys.DiscoveryPassword)
                                .PutAsync($"{ApiKeys.DiscoveryEndpoint}{environmentId}")
                                .WithArgument("version", versionDate)
                                .WithBody<UpdateEnvironmentRequest>(body)
                                .As<Environment>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public Configuration CreateConfiguration(string environmentId, Configuration configuration)
        {
            if (string.IsNullOrEmpty(environmentId))
                throw new ArgumentNullException(nameof(environmentId));
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'DISCOVERY_VERSION_DATE_2017_11_07'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.DiscoveryUsername, ApiKeys.DiscoveryPassword)
                                .PostAsync($"{ApiKeys.DiscoveryEndpoint}{environmentId}/configurations")
                                .WithArgument("version", versionDate)
                                .WithBody<Configuration>(configuration)
                                .As<Configuration>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public DeleteConfigurationResponse DeleteConfiguration(string environmentId, string configurationId)
        {
            if (string.IsNullOrEmpty(environmentId))
                throw new ArgumentNullException(nameof(environmentId));
            if (string.IsNullOrEmpty(configurationId))
                throw new ArgumentNullException(nameof(configurationId));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'DISCOVERY_VERSION_DATE_2017_11_07'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.DiscoveryUsername, ApiKeys.DiscoveryPassword)
                                .DeleteAsync($"{ApiKeys.DiscoveryEndpoint}{environmentId}/configurations/{configurationId}")
                                .WithArgument("version", versionDate)
                                .As<DeleteConfigurationResponse>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public Configuration GetConfiguration(string environmentId, string configurationId)
        {
            if (string.IsNullOrEmpty(environmentId))
                throw new ArgumentNullException(nameof(environmentId));
            if (string.IsNullOrEmpty(configurationId))
                throw new ArgumentNullException(nameof(configurationId));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'DISCOVERY_VERSION_DATE_2017_11_07'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.DiscoveryUsername, ApiKeys.DiscoveryPassword)
                                .GetAsync($"{ApiKeys.DiscoveryEndpoint}{environmentId}/configurations/{configurationId}")
                                .WithArgument("version", versionDate)
                                .As<Configuration>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public ListConfigurationsResponse ListConfigurations(string environmentId, string name = null)
        {
            if (string.IsNullOrEmpty(environmentId))
                throw new ArgumentNullException(nameof(environmentId));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'DISCOVERY_VERSION_DATE_2017_11_07'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.DiscoveryUsername, ApiKeys.DiscoveryPassword)
                                .GetAsync($"{ApiKeys.DiscoveryEndpoint}{environmentId}/configurations")
                                .WithArgument("version", versionDate)
                                .WithArgument("name", name)
                                .As<ListConfigurationsResponse>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public Configuration UpdateConfiguration(string environmentId, string configurationId, Configuration configuration)
        {
            if (string.IsNullOrEmpty(environmentId))
                throw new ArgumentNullException(nameof(environmentId));
            if (string.IsNullOrEmpty(configurationId))
                throw new ArgumentNullException(nameof(configurationId));
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'DISCOVERY_VERSION_DATE_2017_11_07'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.DiscoveryUsername, ApiKeys.DiscoveryPassword)
                                .PutAsync($"{ApiKeys.DiscoveryEndpoint}{environmentId}/configurations/{configurationId}")
                                .WithArgument("version", versionDate)
                                .WithBody<Configuration>(configuration)
                                .As<Configuration>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public TestDocument TestConfigurationInEnvironment(string environmentId, string configuration = null, string step = null, string configurationId = null, System.IO.Stream file = null, string metadata = null, string fileContentType = null)
        {
            if (string.IsNullOrEmpty(environmentId))
                throw new ArgumentNullException(nameof(environmentId));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'DISCOVERY_VERSION_DATE_2017_11_07'");
            
            try
            {
                var formData = new MultipartFormDataContent();

                if (configuration != null)
                {
                    var configurationContent = new StringContent(configuration, Encoding.UTF8, HttpMediaType.TEXT_PLAIN);
                    formData.Add(configurationContent, "configuration");
                }

                if (file != null)
                {
                    var fileContent = new ByteArrayContent((file as Stream).ReadAllBytes());
                    System.Net.Http.Headers.MediaTypeHeaderValue contentType;
                    System.Net.Http.Headers.MediaTypeHeaderValue.TryParse(fileContentType, out contentType);
                    fileContent.Headers.ContentType = contentType;
                    formData.Add(fileContent, "file", "filename");
                }

                if (metadata != null)
                {
                    var metadataContent = new StringContent(metadata, Encoding.UTF8, HttpMediaType.TEXT_PLAIN);
                    formData.Add(metadataContent, "metadata");
                }

                var result = RepositoryClient.WithAuthentication(ApiKeys.DiscoveryUsername, ApiKeys.DiscoveryPassword)
                                .PostAsync($"{ApiKeys.DiscoveryEndpoint}{environmentId}/preview")
                                .WithArgument("version", versionDate)
                                .WithArgument("step", step)
                                .WithArgument("configuration_id", configurationId)
                                .WithBodyContent(formData)
                                .As<TestDocument>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public Collection CreateCollection(string environmentId, CreateCollectionRequest body)
        {
            if (string.IsNullOrEmpty(environmentId))
                throw new ArgumentNullException(nameof(environmentId));
            if (body == null)
                throw new ArgumentNullException(nameof(body));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'DISCOVERY_VERSION_DATE_2017_11_07'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.DiscoveryUsername, ApiKeys.DiscoveryPassword)
                                .PostAsync($"{ApiKeys.DiscoveryEndpoint}{environmentId}/collections")
                                .WithArgument("version", versionDate)
                                .WithBody<CreateCollectionRequest>(body)
                                .As<Collection>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public DeleteCollectionResponse DeleteCollection(string environmentId, string collectionId)
        {
            if (string.IsNullOrEmpty(environmentId))
                throw new ArgumentNullException(nameof(environmentId));
            if (string.IsNullOrEmpty(collectionId))
                throw new ArgumentNullException(nameof(collectionId));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'DISCOVERY_VERSION_DATE_2017_11_07'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.DiscoveryUsername, ApiKeys.DiscoveryPassword)
                                .DeleteAsync($"{ApiKeys.DiscoveryEndpoint}{environmentId}/collections/{collectionId}")
                                .WithArgument("version", versionDate)
                                .As<DeleteCollectionResponse>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public Collection GetCollection(string environmentId, string collectionId)
        {
            if (string.IsNullOrEmpty(environmentId))
                throw new ArgumentNullException(nameof(environmentId));
            if (string.IsNullOrEmpty(collectionId))
                throw new ArgumentNullException(nameof(collectionId));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'DISCOVERY_VERSION_DATE_2017_11_07'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.DiscoveryUsername, ApiKeys.DiscoveryPassword)
                                .GetAsync($"{ApiKeys.DiscoveryEndpoint}{environmentId}/collections/{collectionId}")
                                .WithArgument("version", versionDate)
                                .As<Collection>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public ListCollectionFieldsResponse ListCollectionFields(string environmentId, string collectionId)
        {
            if (string.IsNullOrEmpty(environmentId))
                throw new ArgumentNullException(nameof(environmentId));
            if (string.IsNullOrEmpty(collectionId))
                throw new ArgumentNullException(nameof(collectionId));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'DISCOVERY_VERSION_DATE_2017_11_07'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.DiscoveryUsername, ApiKeys.DiscoveryPassword)
                                .GetAsync($"{ApiKeys.DiscoveryEndpoint}{environmentId}/collections/{collectionId}/fields")
                                .WithArgument("version", versionDate)
                                .As<ListCollectionFieldsResponse>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public ListCollectionsResponse ListCollections(string environmentId, string name = null)
        {
            if (string.IsNullOrEmpty(environmentId))
                throw new ArgumentNullException(nameof(environmentId));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'DISCOVERY_VERSION_DATE_2017_11_07'");

            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.DiscoveryUsername, ApiKeys.DiscoveryPassword)
                                .GetAsync($"{ApiKeys.DiscoveryEndpoint}{environmentId}/collections")
                                .WithArgument("version", versionDate)
                                .WithArgument("name", name)
                                .As<ListCollectionsResponse>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public Collection UpdateCollection(string environmentId, string collectionId, UpdateCollectionRequest body = null)
        {
            if (string.IsNullOrEmpty(environmentId))
                throw new ArgumentNullException(nameof(environmentId));
            if (string.IsNullOrEmpty(collectionId))
                throw new ArgumentNullException(nameof(collectionId));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'DISCOVERY_VERSION_DATE_2017_11_07'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.DiscoveryUsername, ApiKeys.DiscoveryPassword)
                                .PutAsync($"{ApiKeys.DiscoveryEndpoint}{environmentId}/collections/{collectionId}")
                                .WithArgument("version", versionDate)
                                .WithBody<UpdateCollectionRequest>(body)
                                .As<Collection>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public DocumentAccepted AddDocument(string environmentId, string collectionId, System.IO.Stream file = null, string metadata = null, string fileContentType = null)
        {
            if (string.IsNullOrEmpty(environmentId))
                throw new ArgumentNullException(nameof(environmentId));
            if (string.IsNullOrEmpty(collectionId))
                throw new ArgumentNullException(nameof(collectionId));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'DISCOVERY_VERSION_DATE_2017_11_07'");
            
            try
            {
                var formData = new MultipartFormDataContent();

                if (file != null)
                {
                    var fileContent = new ByteArrayContent((file as Stream).ReadAllBytes());
                    System.Net.Http.Headers.MediaTypeHeaderValue contentType;
                    System.Net.Http.Headers.MediaTypeHeaderValue.TryParse(fileContentType, out contentType);
                    fileContent.Headers.ContentType = contentType;
                    formData.Add(fileContent, "file", "filename");
                }

                if (metadata != null)
                {
                    var metadataContent = new StringContent(metadata, Encoding.UTF8, HttpMediaType.TEXT_PLAIN);
                    formData.Add(metadataContent, "metadata");
                }

                var result = RepositoryClient.WithAuthentication(ApiKeys.DiscoveryUsername, ApiKeys.DiscoveryPassword)
                                .PostAsync($"{ApiKeys.DiscoveryEndpoint}{environmentId}/collections/{collectionId}/documents")
                                .WithArgument("version", versionDate)
                                .WithBodyContent(formData)
                                .As<DocumentAccepted>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public DeleteDocumentResponse DeleteDocument(string environmentId, string collectionId, string documentId)
        {
            if (string.IsNullOrEmpty(environmentId))
                throw new ArgumentNullException(nameof(environmentId));
            if (string.IsNullOrEmpty(collectionId))
                throw new ArgumentNullException(nameof(collectionId));
            if (string.IsNullOrEmpty(documentId))
                throw new ArgumentNullException(nameof(documentId));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'DISCOVERY_VERSION_DATE_2017_11_07'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.DiscoveryUsername, ApiKeys.DiscoveryPassword)
                                .DeleteAsync($"{ApiKeys.DiscoveryEndpoint}{environmentId}/collections/{collectionId}/documents/{documentId}")
                                .WithArgument("version", versionDate)
                                .As<DeleteDocumentResponse>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public DocumentStatus GetDocumentStatus(string environmentId, string collectionId, string documentId)
        {
            if (string.IsNullOrEmpty(environmentId))
                throw new ArgumentNullException(nameof(environmentId));
            if (string.IsNullOrEmpty(collectionId))
                throw new ArgumentNullException(nameof(collectionId));
            if (string.IsNullOrEmpty(documentId))
                throw new ArgumentNullException(nameof(documentId));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'DISCOVERY_VERSION_DATE_2017_11_07'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.DiscoveryUsername, ApiKeys.DiscoveryPassword)
                                .GetAsync($"{ApiKeys.DiscoveryEndpoint}{environmentId}/collections/{collectionId}/documents/{documentId}")
                                .WithArgument("version", versionDate)
                                .As<DocumentStatus>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public DocumentAccepted UpdateDocument(string environmentId, string collectionId, string documentId, System.IO.Stream file = null, string metadata = null, string fileContentType = null)
        {
            if (string.IsNullOrEmpty(environmentId))
                throw new ArgumentNullException(nameof(environmentId));
            if (string.IsNullOrEmpty(collectionId))
                throw new ArgumentNullException(nameof(collectionId));
            if (string.IsNullOrEmpty(documentId))
                throw new ArgumentNullException(nameof(documentId));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'DISCOVERY_VERSION_DATE_2017_11_07'");
            
            try
            {
                var formData = new MultipartFormDataContent();

                if (file != null)
                {
                    var fileContent = new ByteArrayContent((file as Stream).ReadAllBytes());
                    System.Net.Http.Headers.MediaTypeHeaderValue contentType;
                    System.Net.Http.Headers.MediaTypeHeaderValue.TryParse(fileContentType, out contentType);
                    fileContent.Headers.ContentType = contentType;
                    formData.Add(fileContent, "file", "filename");
                }

                if (metadata != null)
                {
                    var metadataContent = new StringContent(metadata, Encoding.UTF8, HttpMediaType.TEXT_PLAIN);
                    formData.Add(metadataContent, "metadata");
                }

                var result = RepositoryClient.WithAuthentication(ApiKeys.DiscoveryUsername, ApiKeys.DiscoveryPassword)
                                .PostAsync($"{ApiKeys.DiscoveryEndpoint}{environmentId}/collections/{collectionId}/documents/{documentId}")
                                .WithArgument("version", versionDate)
                                .WithBodyContent(formData)
                                .As<DocumentAccepted>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public QueryResponse FederatedQuery(string environmentId, List<string> collectionIds, string filter = null, string query = null, string naturalLanguageQuery = null, string aggregation = null, long? count = null, List<string> returnFields = null, long? offset = null, List<string> sort = null, bool? highlight = null, bool? deduplicate = null, string deduplicateField = null)
        {
            if (string.IsNullOrEmpty(environmentId))
                throw new ArgumentNullException(nameof(environmentId));
            if (collectionIds == null)
                throw new ArgumentNullException(nameof(collectionIds));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'DISCOVERY_VERSION_DATE_2017_11_07'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.DiscoveryUsername, ApiKeys.DiscoveryPassword)
                                .GetAsync($"{ApiKeys.DiscoveryEndpoint}{environmentId}/query")
                                .WithArgument("version", versionDate)
                                .WithArgument("collection_ids", collectionIds != null && collectionIds.Count > 0 ? string.Join(",", collectionIds.ToArray()) : null)
                                .WithArgument("filter", filter)
                                .WithArgument("query", query)
                                .WithArgument("natural_language_query", naturalLanguageQuery)
                                .WithArgument("aggregation", aggregation)
                                .WithArgument("count", count)
                                .WithArgument("return_fields", returnFields != null && returnFields.Count > 0 ? string.Join(",", returnFields.ToArray()) : null)
                                .WithArgument("offset", offset)
                                .WithArgument("sort", sort != null && sort.Count > 0 ? string.Join(",", sort.ToArray()) : null)
                                .WithArgument("highlight", highlight)
                                .WithArgument("deduplicate", deduplicate)
                                .WithArgument("deduplicate.field", deduplicateField)
                                .As<QueryResponse>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public QueryNoticesResponse FederatedQueryNotices(string environmentId, List<string> collectionIds, string filter = null, string query = null, string naturalLanguageQuery = null, string aggregation = null, long? count = null, List<string> returnFields = null, long? offset = null, List<string> sort = null, bool? highlight = null, string deduplicateField = null)
        {
            if (string.IsNullOrEmpty(environmentId))
                throw new ArgumentNullException(nameof(environmentId));
            if (collectionIds == null)
                throw new ArgumentNullException(nameof(collectionIds));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'DISCOVERY_VERSION_DATE_2017_11_07'");
        
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.DiscoveryUsername, ApiKeys.DiscoveryPassword)
                                .GetAsync($"{ApiKeys.DiscoveryEndpoint}{environmentId}/notices")
                                .WithArgument("version", versionDate)
                                .WithArgument("collection_ids", collectionIds != null && collectionIds.Count > 0 ? string.Join(",", collectionIds.ToArray()) : null)
                                .WithArgument("filter", filter)
                                .WithArgument("query", query)
                                .WithArgument("natural_language_query", naturalLanguageQuery)
                                .WithArgument("aggregation", aggregation)
                                .WithArgument("count", count)
                                .WithArgument("return_fields", returnFields != null && returnFields.Count > 0 ? string.Join(",", returnFields.ToArray()) : null)
                                .WithArgument("offset", offset)
                                .WithArgument("sort", sort != null && sort.Count > 0 ? string.Join(",", sort.ToArray()) : null)
                                .WithArgument("highlight", highlight)
                                .WithArgument("deduplicate.field", deduplicateField)
                                .As<QueryNoticesResponse>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public QueryResponse Query(string environmentId, string collectionId, string filter = null, string query = null, string naturalLanguageQuery = null, bool? passages = null, string aggregation = null, long? count = null, List<string> returnFields = null, long? offset = null, List<string> sort = null, bool? highlight = null, List<string> passagesFields = null, long? passagesCount = null, long? passagesCharacters = null, bool? deduplicate = null, string deduplicateField = null)
        {
            if (string.IsNullOrEmpty(environmentId))
                throw new ArgumentNullException(nameof(environmentId));
            if (string.IsNullOrEmpty(collectionId))
                throw new ArgumentNullException(nameof(collectionId));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'DISCOVERY_VERSION_DATE_2017_11_07'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.DiscoveryUsername, ApiKeys.DiscoveryPassword)
                                .GetAsync($"{ApiKeys.DiscoveryEndpoint}{environmentId}/collections/{collectionId}/query")
                                .WithArgument("version", versionDate)
                                .WithArgument("filter", filter)
                                .WithArgument("query", query)
                                .WithArgument("natural_language_query", naturalLanguageQuery)
                                .WithArgument("passages", passages)
                                .WithArgument("aggregation", aggregation)
                                .WithArgument("count", count)
                                .WithArgument("return", returnFields != null && returnFields.Count > 0 ? string.Join(",", returnFields.ToArray()) : null)
                                .WithArgument("offset", offset)
                                .WithArgument("sort", sort != null && sort.Count > 0 ? string.Join(",", sort.ToArray()) : null)
                                .WithArgument("highlight", highlight)
                                .WithArgument("passages.fields", passagesFields != null && passagesFields.Count > 0 ? string.Join(",", passagesFields.ToArray()) : null)
                                .WithArgument("passages.count", passagesCount)
                                .WithArgument("passages.characters", passagesCharacters)
                                .WithArgument("deduplicate", deduplicate)
                                .WithArgument("deduplicate.field", deduplicateField)
                                .As<QueryResponse>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public QueryEntitiesResponse QueryEntities(string environmentId, string collectionId, QueryEntities entityQuery)
        {
            if (string.IsNullOrEmpty(environmentId))
                throw new ArgumentNullException(nameof(environmentId));
            if (string.IsNullOrEmpty(collectionId))
                throw new ArgumentNullException(nameof(collectionId));
            if (entityQuery == null)
                throw new ArgumentNullException(nameof(entityQuery));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'DISCOVERY_VERSION_DATE_2017_11_07'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.DiscoveryUsername, ApiKeys.DiscoveryPassword)
                                .PostAsync($"{ApiKeys.DiscoveryEndpoint}{environmentId}/collections/{collectionId}/query_entities")
                                .WithArgument("version", versionDate)
                                .WithBody<QueryEntities>(entityQuery)
                                .As<QueryEntitiesResponse>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public QueryNoticesResponse QueryNotices(string environmentId, string collectionId, string filter = null, string query = null, string naturalLanguageQuery = null, bool? passages = null, string aggregation = null, long? count = null, List<string> returnFields = null, long? offset = null, List<string> sort = null, bool? highlight = null, List<string> passagesFields = null, long? passagesCount = null, long? passagesCharacters = null, string deduplicateField = null)
        {
            if (string.IsNullOrEmpty(environmentId))
                throw new ArgumentNullException(nameof(environmentId));
            if (string.IsNullOrEmpty(collectionId))
                throw new ArgumentNullException(nameof(collectionId));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'DISCOVERY_VERSION_DATE_2017_11_07'");

            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.DiscoveryUsername, ApiKeys.DiscoveryPassword)
                                .GetAsync($"{ApiKeys.DiscoveryEndpoint}{environmentId}/collections/{collectionId}/notices")
                                .WithArgument("version", versionDate)
                                .WithArgument("filter", filter)
                                .WithArgument("query", query)
                                .WithArgument("natural_language_query", naturalLanguageQuery)
                                .WithArgument("passages", passages)
                                .WithArgument("aggregation", aggregation)
                                .WithArgument("count", count)
                                .WithArgument("return_fields", returnFields != null && returnFields.Count > 0 ? string.Join(",", returnFields.ToArray()) : null)
                                .WithArgument("offset", offset)
                                .WithArgument("sort", sort != null && sort.Count > 0 ? string.Join(",", sort.ToArray()) : null)
                                .WithArgument("highlight", highlight)
                                .WithArgument("passages.fields", passagesFields != null && passagesFields.Count > 0 ? string.Join(",", passagesFields.ToArray()) : null)
                                .WithArgument("passages.count", passagesCount)
                                .WithArgument("passages.characters", passagesCharacters)
                                .WithArgument("deduplicate.field", deduplicateField)
                                .As<QueryNoticesResponse>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public QueryRelationsResponse QueryRelations(string environmentId, string collectionId, QueryRelations relationshipQuery)
        {
            if (string.IsNullOrEmpty(environmentId))
                throw new ArgumentNullException(nameof(environmentId));
            if (string.IsNullOrEmpty(collectionId))
                throw new ArgumentNullException(nameof(collectionId));
            if (relationshipQuery == null)
                throw new ArgumentNullException(nameof(relationshipQuery));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'DISCOVERY_VERSION_DATE_2017_11_07'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.DiscoveryUsername, ApiKeys.DiscoveryPassword)
                                .PostAsync($"{ApiKeys.DiscoveryEndpoint}{environmentId}/collections/{collectionId}/query_relations")
                                .WithArgument("version", versionDate)
                                .WithBody<QueryRelations>(relationshipQuery)
                                .As<QueryRelationsResponse>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public TrainingQuery AddTrainingData(string environmentId, string collectionId, NewTrainingQuery body)
        {
            if (string.IsNullOrEmpty(environmentId))
                throw new ArgumentNullException(nameof(environmentId));
            if (string.IsNullOrEmpty(collectionId))
                throw new ArgumentNullException(nameof(collectionId));
            if (body == null)
                throw new ArgumentNullException(nameof(body));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'DISCOVERY_VERSION_DATE_2017_11_07'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.DiscoveryUsername, ApiKeys.DiscoveryPassword)
                                .PostAsync($"{ApiKeys.DiscoveryEndpoint}{environmentId}/collections/{collectionId}/training_data")
                                .WithArgument("version", versionDate)
                                .WithBody<NewTrainingQuery>(body)
                                .As<TrainingQuery>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public TrainingExample CreateTrainingExample(string environmentId, string collectionId, string queryId, TrainingExample body)
        {
            if (string.IsNullOrEmpty(environmentId))
                throw new ArgumentNullException(nameof(environmentId));
            if (string.IsNullOrEmpty(collectionId))
                throw new ArgumentNullException(nameof(collectionId));
            if (string.IsNullOrEmpty(queryId))
                throw new ArgumentNullException(nameof(queryId));
            if (body == null)
                throw new ArgumentNullException(nameof(body));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'DISCOVERY_VERSION_DATE_2017_11_07'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.DiscoveryUsername, ApiKeys.DiscoveryPassword)
                                .PostAsync($"{ApiKeys.DiscoveryEndpoint}{environmentId}/collections/{collectionId}/training_data/{queryId}/examples")
                                .WithArgument("version", versionDate)
                                .WithBody<TrainingExample>(body)
                                .As<TrainingExample>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public object DeleteAllTrainingData(string environmentId, string collectionId)
        {
            if (string.IsNullOrEmpty(environmentId))
                throw new ArgumentNullException(nameof(environmentId));
            if (string.IsNullOrEmpty(collectionId))
                throw new ArgumentNullException(nameof(collectionId));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'DISCOVERY_VERSION_DATE_2017_11_07'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.DiscoveryUsername, ApiKeys.DiscoveryPassword)
                                .DeleteAsync($"{ApiKeys.DiscoveryEndpoint}{environmentId}/collections/{collectionId}/training_data")
                                .WithArgument("version", versionDate)
                                .As<object>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public object DeleteTrainingData(string environmentId, string collectionId, string queryId)
        {
            if (string.IsNullOrEmpty(environmentId))
                throw new ArgumentNullException(nameof(environmentId));
            if (string.IsNullOrEmpty(collectionId))
                throw new ArgumentNullException(nameof(collectionId));
            if (string.IsNullOrEmpty(queryId))
                throw new ArgumentNullException(nameof(queryId));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'DISCOVERY_VERSION_DATE_2017_11_07'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.DiscoveryUsername, ApiKeys.DiscoveryPassword)
                                .DeleteAsync($"{ApiKeys.DiscoveryEndpoint}{environmentId}/collections/{collectionId}/training_data/{queryId}")
                                .WithArgument("version", versionDate)
                                .As<object>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public object DeleteTrainingExample(string environmentId, string collectionId, string queryId, string exampleId)
        {
            if (string.IsNullOrEmpty(environmentId))
                throw new ArgumentNullException(nameof(environmentId));
            if (string.IsNullOrEmpty(collectionId))
                throw new ArgumentNullException(nameof(collectionId));
            if (string.IsNullOrEmpty(queryId))
                throw new ArgumentNullException(nameof(queryId));
            if (string.IsNullOrEmpty(exampleId))
                throw new ArgumentNullException(nameof(exampleId));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'DISCOVERY_VERSION_DATE_2017_11_07'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.DiscoveryUsername, ApiKeys.DiscoveryPassword)
                                .DeleteAsync($"{ApiKeys.DiscoveryEndpoint}{environmentId}/collections/{collectionId}/training_data/{queryId}/examples/{exampleId}")
                                .WithArgument("version", versionDate)
                                .As<object>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public TrainingQuery GetTrainingData(string environmentId, string collectionId, string queryId)
        {
            if (string.IsNullOrEmpty(environmentId))
                throw new ArgumentNullException(nameof(environmentId));
            if (string.IsNullOrEmpty(collectionId))
                throw new ArgumentNullException(nameof(collectionId));
            if (string.IsNullOrEmpty(queryId))
                throw new ArgumentNullException(nameof(queryId));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'DISCOVERY_VERSION_DATE_2017_11_07'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.DiscoveryUsername, ApiKeys.DiscoveryPassword)
                                .GetAsync($"{ApiKeys.DiscoveryEndpoint}{environmentId}/collections/{collectionId}/training_data/{queryId}")
                                .WithArgument("version", versionDate)
                                .As<TrainingQuery>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public TrainingExample GetTrainingExample(string environmentId, string collectionId, string queryId, string exampleId)
        {
            if (string.IsNullOrEmpty(environmentId))
                throw new ArgumentNullException(nameof(environmentId));
            if (string.IsNullOrEmpty(collectionId))
                throw new ArgumentNullException(nameof(collectionId));
            if (string.IsNullOrEmpty(queryId))
                throw new ArgumentNullException(nameof(queryId));
            if (string.IsNullOrEmpty(exampleId))
                throw new ArgumentNullException(nameof(exampleId));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'DISCOVERY_VERSION_DATE_2017_11_07'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.DiscoveryUsername, ApiKeys.DiscoveryPassword)
                                .GetAsync($"{ApiKeys.DiscoveryEndpoint}{environmentId}/collections/{collectionId}/training_data/{queryId}/examples/{exampleId}")
                                .WithArgument("version", versionDate)
                                .As<TrainingExample>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public TrainingDataSet ListTrainingData(string environmentId, string collectionId)
        {
            if (string.IsNullOrEmpty(environmentId))
                throw new ArgumentNullException(nameof(environmentId));
            if (string.IsNullOrEmpty(collectionId))
                throw new ArgumentNullException(nameof(collectionId));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'DISCOVERY_VERSION_DATE_2017_11_07'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.DiscoveryUsername, ApiKeys.DiscoveryPassword)
                                .GetAsync($"{ApiKeys.DiscoveryEndpoint}{environmentId}/collections/{collectionId}/training_data")
                                .WithArgument("version", versionDate)
                                .As<TrainingDataSet>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public TrainingExampleList ListTrainingExamples(string environmentId, string collectionId, string queryId)
        {
            if (string.IsNullOrEmpty(environmentId))
                throw new ArgumentNullException(nameof(environmentId));
            if (string.IsNullOrEmpty(collectionId))
                throw new ArgumentNullException(nameof(collectionId));
            if (string.IsNullOrEmpty(queryId))
                throw new ArgumentNullException(nameof(queryId));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'DISCOVERY_VERSION_DATE_2017_11_07'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.DiscoveryUsername, ApiKeys.DiscoveryPassword)
                                .GetAsync($"{ApiKeys.DiscoveryEndpoint}{environmentId}/collections/{collectionId}/training_data/{queryId}/examples")
                                .WithArgument("version", versionDate)
                                .As<TrainingExampleList>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public TrainingExample UpdateTrainingExample(string environmentId, string collectionId, string queryId, string exampleId, TrainingExamplePatch body)
        {
            if (string.IsNullOrEmpty(environmentId))
                throw new ArgumentNullException(nameof(environmentId));
            if (string.IsNullOrEmpty(collectionId))
                throw new ArgumentNullException(nameof(collectionId));
            if (string.IsNullOrEmpty(queryId))
                throw new ArgumentNullException(nameof(queryId));
            if (string.IsNullOrEmpty(exampleId))
                throw new ArgumentNullException(nameof(exampleId));
            if (body == null)
                throw new ArgumentNullException(nameof(body));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'DISCOVERY_VERSION_DATE_2017_11_07'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.DiscoveryUsername, ApiKeys.DiscoveryPassword)
                                .PutAsync($"{ApiKeys.DiscoveryEndpoint}{environmentId}/collections/{collectionId}/training_data/{queryId}/examples/{exampleId}")
                                .WithArgument("version", versionDate)
                                .WithBody<TrainingExamplePatch>(body)
                                .As<TrainingExample>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }
    }
}
