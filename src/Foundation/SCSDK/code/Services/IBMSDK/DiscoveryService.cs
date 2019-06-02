using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using SitecoreCognitiveServices.Foundation.IBMSDK.Discovery;
using SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using Environment = SitecoreCognitiveServices.Foundation.IBMSDK.Discovery.Models.Environment;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.IBMSDK
{
    public class DiscoveryService : IDiscoveryService
    {
        protected IDiscoveryRepository DiscoveryRepository;
        protected ILogWrapper Logger;

        public DiscoveryService(
            IDiscoveryRepository discoveryRepository,
            ILogWrapper logger)
        {
            DiscoveryRepository = discoveryRepository;
            Logger = logger;
        }

        public Environment CreateEnvironment(CreateEnvironmentRequest body)
        {
            try
            {
                var result = DiscoveryRepository.CreateEnvironment(body);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DiscoveryService.CreateEnvironment failed", this, ex);
            }

            return null;
        }

        public DeleteEnvironmentResponse DeleteEnvironment(string environmentId)
        {
            try
            {
                var result = DiscoveryRepository.DeleteEnvironment(environmentId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DiscoveryService.DeleteEnvironment failed", this, ex);
            }

            return null;
        }

        public Environment GetEnvironment(string environmentId)
        {
            try
            {
                var result = DiscoveryRepository.GetEnvironment(environmentId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DiscoveryService.GetEnvironment failed", this, ex);
            }

            return null;
        }

        public ListEnvironmentsResponse ListEnvironments(string name = null)
        {
            try
            {
                var result = DiscoveryRepository.ListEnvironments(name);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DiscoveryService.ListEnvironments failed", this, ex);
            }

            return null;
        }

        public ListCollectionFieldsResponse ListFields(string environmentId, List<string> collectionIds)
        {
            try
            {
                var result = DiscoveryRepository.ListFields(environmentId, collectionIds);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DiscoveryService.ListFields failed", this, ex);
            }

            return null;
        }

        public Environment UpdateEnvironment(string environmentId, UpdateEnvironmentRequest body)
        {
            try
            {
                var result = DiscoveryRepository.UpdateEnvironment(environmentId, body);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DiscoveryService.UpdateEnvironment failed", this, ex);
            }

            return null;
        }

        public Configuration CreateConfiguration(string environmentId, Configuration configuration)
        {
            try
            {
                var result = DiscoveryRepository.CreateConfiguration(environmentId, configuration);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DiscoveryService.CreateConfiguration failed", this, ex);
            }

            return null;
        }

        public DeleteConfigurationResponse DeleteConfiguration(string environmentId, string configurationId)
        {
            try
            {
                var result = DiscoveryRepository.DeleteConfiguration(environmentId, configurationId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DiscoveryService.DeleteConfiguration failed", this, ex);
            }

            return null;
        }

        public Configuration GetConfiguration(string environmentId, string configurationId)
        {
            try
            {
                var result = DiscoveryRepository.GetConfiguration(environmentId, configurationId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DiscoveryService.GetConfiguration failed", this, ex);
            }

            return null;
        }

        public ListConfigurationsResponse ListConfigurations(string environmentId, string name = null)
        {
            try
            {
                var result = DiscoveryRepository.ListConfigurations(environmentId, name);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DiscoveryService.ListConfigurations failed", this, ex);
            }

            return null;
        }

        public Configuration UpdateConfiguration(string environmentId, string configurationId, Configuration configuration)
        {
            try
            {
                var result = DiscoveryRepository.UpdateConfiguration(environmentId, configurationId, configuration);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DiscoveryService.UpdateConfiguration failed", this, ex);
            }

            return null;
        }

        public TestDocument TestConfigurationInEnvironment(string environmentId, string configuration = null, string step = null, string configurationId = null, System.IO.Stream file = null, string metadata = null, string fileContentType = null)
        {
            try
            {
                var result = DiscoveryRepository.TestConfigurationInEnvironment(environmentId, configuration, step, configurationId, file, metadata, fileContentType);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DiscoveryService.TestConfigurationInEnvironment failed", this, ex);
            }

            return null;
        }

        public Collection CreateCollection(string environmentId, CreateCollectionRequest body)
        {
            try
            {
                var result = DiscoveryRepository.CreateCollection(environmentId, body);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DiscoveryService.CreateCollection failed", this, ex);
            }

            return null;
        }

        public DeleteCollectionResponse DeleteCollection(string environmentId, string collectionId)
        {
            try
            {
                var result = DiscoveryRepository.DeleteCollection(environmentId, collectionId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DiscoveryService.DeleteCollection failed", this, ex);
            }

            return null;
        }

        public Collection GetCollection(string environmentId, string collectionId)
        {
            try
            {
                var result = DiscoveryRepository.GetCollection(environmentId, collectionId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DiscoveryService.GetCollection failed", this, ex);
            }

            return null;
        }

        public ListCollectionFieldsResponse ListCollectionFields(string environmentId, string collectionId)
        {
            try
            {
                var result = DiscoveryRepository.ListCollectionFields(environmentId, collectionId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DiscoveryService.ListCollectionFields failed", this, ex);
            }

            return null;
        }

        public ListCollectionsResponse ListCollections(string environmentId, string name = null)
        {
            try
            {
                var result = DiscoveryRepository.ListCollections(environmentId, name);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DiscoveryService.ListCollections failed", this, ex);
            }

            return null;
        }

        public Collection UpdateCollection(string environmentId, string collectionId, UpdateCollectionRequest body = null)
        {
            try
            {
                var result = DiscoveryRepository.UpdateCollection(environmentId, collectionId, body);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DiscoveryService.UpdateCollection failed", this, ex);
            }

            return null;
        }

        public DocumentAccepted AddDocument(string environmentId, string collectionId, System.IO.Stream file = null, string metadata = null, string fileContentType = null)
        {
            try
            {
                var result = DiscoveryRepository.AddDocument(environmentId, collectionId, file, metadata, fileContentType);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DiscoveryService.AddDocument failed", this, ex);
            }

            return null;
        }

        public DeleteDocumentResponse DeleteDocument(string environmentId, string collectionId, string documentId)
        {
            try
            {
                var result = DiscoveryRepository.DeleteDocument(environmentId, collectionId, documentId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DiscoveryService.DeleteDocument failed", this, ex);
            }

            return null;
        }

        public DocumentStatus GetDocumentStatus(string environmentId, string collectionId, string documentId)
        {
            try
            {
                var result = DiscoveryRepository.GetDocumentStatus(environmentId, collectionId, documentId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DiscoveryService.GetDocumentStatus failed", this, ex);
            }

            return null;
        }

        public DocumentAccepted UpdateDocument(string environmentId, string collectionId, string documentId, System.IO.Stream file = null, string metadata = null, string fileContentType = null)
        {
            try
            {
                var result = DiscoveryRepository.UpdateDocument(environmentId, collectionId, documentId, file, metadata, fileContentType);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DiscoveryService.UpdateDocument failed", this, ex);
            }

            return null;
        }

        public QueryResponse FederatedQuery(string environmentId, List<string> collectionIds, string filter = null, string query = null, string naturalLanguageQuery = null, string aggregation = null, long? count = null, List<string> returnFields = null, long? offset = null, List<string> sort = null, bool? highlight = null, bool? deduplicate = null, string deduplicateField = null)
        {
            try
            {
                var result = DiscoveryRepository.FederatedQuery(environmentId, collectionIds, filter, query, naturalLanguageQuery, aggregation, count, returnFields, offset, sort, highlight, deduplicate, deduplicateField);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DiscoveryService.FederatedQuery failed", this, ex);
            }

            return null;
        }

        public QueryNoticesResponse FederatedQueryNotices(string environmentId, List<string> collectionIds, string filter = null, string query = null, string naturalLanguageQuery = null, string aggregation = null, long? count = null, List<string> returnFields = null, long? offset = null, List<string> sort = null, bool? highlight = null, string deduplicateField = null)
        {
            try
            {
                var result = DiscoveryRepository.FederatedQueryNotices(environmentId, collectionIds, filter, query, naturalLanguageQuery, aggregation, count, returnFields, offset, sort, highlight, deduplicateField);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DiscoveryService.FederatedQueryNotices failed", this, ex);
            }

            return null;
        }

        public QueryResponse Query(string environmentId, string collectionId, string filter = null, string query = null, string naturalLanguageQuery = null, bool? passages = null, string aggregation = null, long? count = null, List<string> returnFields = null, long? offset = null, List<string> sort = null, bool? highlight = null, List<string> passagesFields = null, long? passagesCount = null, long? passagesCharacters = null, bool? deduplicate = null, string deduplicateField = null)
        {
            try
            {
                var result = DiscoveryRepository.Query(environmentId, collectionId, filter, query, naturalLanguageQuery, passages, aggregation, count, returnFields, offset, sort, highlight, passagesFields, passagesCount, passagesCharacters, deduplicate, deduplicateField);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DiscoveryService.Query failed", this, ex);
            }

            return null;
        }

        public QueryEntitiesResponse QueryEntities(string environmentId, string collectionId, QueryEntities entityQuery)
        {
            try
            {
                var result = DiscoveryRepository.QueryEntities(environmentId, collectionId, entityQuery);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DiscoveryService.QueryEntities failed", this, ex);
            }

            return null;
        }

        public QueryNoticesResponse QueryNotices(string environmentId, string collectionId, string filter = null, string query = null, string naturalLanguageQuery = null, bool? passages = null, string aggregation = null, long? count = null, List<string> returnFields = null, long? offset = null, List<string> sort = null, bool? highlight = null, List<string> passagesFields = null, long? passagesCount = null, long? passagesCharacters = null, string deduplicateField = null)
        {
            try
            {
                var result = DiscoveryRepository.QueryNotices(environmentId, collectionId, filter, query, naturalLanguageQuery, passages, aggregation, count, returnFields, offset, sort, highlight, passagesFields, passagesCount, passagesCharacters, deduplicateField);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DiscoveryService.QueryNotices failed", this, ex);
            }

            return null;
        }

        public QueryRelationsResponse QueryRelations(string environmentId, string collectionId, QueryRelations relationshipQuery)
        {
            try
            {
                var result = DiscoveryRepository.QueryRelations(environmentId, collectionId, relationshipQuery);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DiscoveryService.QueryRelations failed", this, ex);
            }

            return null;
        }

        public TrainingQuery AddTrainingData(string environmentId, string collectionId, NewTrainingQuery body)
        {
            try
            {
                var result = DiscoveryRepository.AddTrainingData(environmentId, collectionId, body);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DiscoveryService.AddTrainingData failed", this, ex);
            }

            return null;
        }

        public TrainingExample CreateTrainingExample(string environmentId, string collectionId, string queryId, TrainingExample body)
        {
            try
            {
                var result = DiscoveryRepository.CreateTrainingExample(environmentId, collectionId, queryId, body);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DiscoveryService.CreateTrainingExample failed", this, ex);
            }

            return null;
        }

        public object DeleteAllTrainingData(string environmentId, string collectionId)
        {
            try
            {
                var result = DiscoveryRepository.DeleteAllTrainingData(environmentId, collectionId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DiscoveryService.DeleteAllTrainingData failed", this, ex);
            }

            return null;
        }

        public object DeleteTrainingData(string environmentId, string collectionId, string queryId)
        {
            try
            {
                var result = DiscoveryRepository.DeleteTrainingData(environmentId, collectionId, queryId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DiscoveryService.DeleteTrainingData failed", this, ex);
            }

            return null;
        }

        public object DeleteTrainingExample(string environmentId, string collectionId, string queryId, string exampleId)
        {
            try
            {
                var result = DiscoveryRepository.DeleteTrainingExample(environmentId, collectionId, queryId, exampleId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DiscoveryService.DeleteTrainingExample failed", this, ex);
            }

            return null;
        }

        public TrainingQuery GetTrainingData(string environmentId, string collectionId, string queryId)
        {
            try
            {
                var result = DiscoveryRepository.GetTrainingData(environmentId, collectionId, queryId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DiscoveryService.GetTrainingData failed", this, ex);
            }

            return null;
        }

        public TrainingExample GetTrainingExample(string environmentId, string collectionId, string queryId, string exampleId)
        {
            try
            {
                var result = DiscoveryRepository.GetTrainingExample(environmentId, collectionId, queryId, exampleId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DiscoveryService.GetTrainingExample failed", this, ex);
            }

            return null;
        }

        public TrainingDataSet ListTrainingData(string environmentId, string collectionId)
        {
            try
            {
                var result = DiscoveryRepository.ListTrainingData(environmentId, collectionId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DiscoveryService.ListTrainingData failed", this, ex);
            }

            return null;
        }

        public TrainingExampleList ListTrainingExamples(string environmentId, string collectionId, string queryId)
        {
            try
            {
                var result = DiscoveryRepository.ListTrainingExamples(environmentId, collectionId, queryId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DiscoveryService.ListTrainingExamples failed", this, ex);
            }

            return null;
        }

        public TrainingExample UpdateTrainingExample(string environmentId, string collectionId, string queryId, string exampleId, TrainingExamplePatch body)
        {
            try
            {
                var result = DiscoveryRepository.UpdateTrainingExample(environmentId, collectionId, queryId, exampleId, body);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("DiscoveryService.UpdateTrainingExample failed", this, ex);
            }

            return null;
        }
    }
}