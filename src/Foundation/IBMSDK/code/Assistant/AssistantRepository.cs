using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System;
using SitecoreCognitiveServices.Foundation.IBMSDK.Assistant.Models;
using SitecoreCognitiveServices.Foundation.IBMSDK.Http;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Assistant
{
    public class AssistantRepository : IAssistantRepository
    {
        #region Constructor

        protected static readonly string conversationUrl = "/conversation";
        protected static readonly string versionDate = "2017-05-26";

        protected readonly IIBMWatsonApiKeys ApiKeys;
        protected readonly IIBMWatsonRepositoryClient RepositoryClient;

        public AssistantRepository(
            IIBMWatsonApiKeys apiKeys,
            IIBMWatsonRepositoryClient repositoryClient)
        {
            ApiKeys = apiKeys;
            RepositoryClient = repositoryClient;
        }

        #endregion
        
        public Workspace CreateWorkspace(CreateWorkspace properties = null)
        {
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'CONVERSATION_VERSION_DATE_2017_05_26'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.AssistantUsername, ApiKeys.AssistantPassword)
                                .PostAsync($"{ApiKeys.AssistantEndpoint}")
                                .WithArgument("version", versionDate)
                                .WithBody<CreateWorkspace>(properties)
                                .As<Workspace>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public object DeleteWorkspace(string workspaceId)
        {
            if (string.IsNullOrEmpty(workspaceId))
                throw new ArgumentNullException(nameof(workspaceId));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'CONVERSATION_VERSION_DATE_2017_05_26'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.AssistantUsername, ApiKeys.AssistantPassword)
                                .DeleteAsync($"{ApiKeys.AssistantEndpoint}{workspaceId}")
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

        public WorkspaceExport GetWorkspace(string workspaceId, bool? export = null)
        {
            if (string.IsNullOrEmpty(workspaceId))
                throw new ArgumentNullException(nameof(workspaceId));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'CONVERSATION_VERSION_DATE_2017_05_26'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.AssistantUsername, ApiKeys.AssistantPassword)
                                .GetAsync($"{ApiKeys.AssistantEndpoint}{workspaceId}")
                                .WithArgument("version", versionDate)
                                .WithArgument("export", export)
                                .As<WorkspaceExport>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public WorkspaceCollection ListWorkspaces(long? pageLimit = null, bool? includeCount = null, string sort = null, string cursor = null)
        {
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'CONVERSATION_VERSION_DATE_2017_05_26'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.AssistantUsername, ApiKeys.AssistantPassword)
                                .GetAsync($"{ApiKeys.AssistantEndpoint}")
                                .WithArgument("version", versionDate)
                                .WithArgument("page_limit", pageLimit)
                                .WithArgument("include_count", includeCount)
                                .WithArgument("sort", sort)
                                .WithArgument("cursor", cursor)
                                .As<WorkspaceCollection>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public Workspace UpdateWorkspace(string workspaceId, UpdateWorkspace properties = null, bool? append = null)
        {
            if (string.IsNullOrEmpty(workspaceId))
                throw new ArgumentNullException(nameof(workspaceId));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'CONVERSATION_VERSION_DATE_2017_05_26'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.AssistantUsername, ApiKeys.AssistantPassword)
                                .PostAsync($"{ApiKeys.AssistantEndpoint}{workspaceId}")
                                .WithArgument("version", versionDate)
                                .WithArgument("append", append)
                                .WithBody<UpdateWorkspace>(properties)
                                .As<Workspace>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public MessageResponse Message(string workspaceId, MessageRequest request = null)
        {
            if (string.IsNullOrEmpty(workspaceId))
                throw new ArgumentNullException(nameof(workspaceId));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'CONVERSATION_VERSION_DATE_2017_05_26'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.AssistantUsername, ApiKeys.AssistantPassword)
                                .PostAsync($"{ApiKeys.AssistantEndpoint}{workspaceId}/message")
                                .WithArgument("version", versionDate)
                                .WithBody<MessageRequest>(request)
                                .As<MessageResponse>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public Intent CreateIntent(string workspaceId, CreateIntent body)
        {
            if (string.IsNullOrEmpty(workspaceId))
                throw new ArgumentNullException(nameof(workspaceId));
            if (body == null)
                throw new ArgumentNullException(nameof(body));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'CONVERSATION_VERSION_DATE_2017_05_26'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.AssistantUsername, ApiKeys.AssistantPassword)
                                .PostAsync($"{ApiKeys.AssistantEndpoint}{workspaceId}/intents")
                                .WithArgument("version", versionDate)
                                .WithBody<CreateIntent>(body)
                                .As<Intent>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public object DeleteIntent(string workspaceId, string intent)
        {
            if (string.IsNullOrEmpty(workspaceId))
                throw new ArgumentNullException(nameof(workspaceId));
            if (string.IsNullOrEmpty(intent))
                throw new ArgumentNullException(nameof(intent));

            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'CONVERSATION_VERSION_DATE_2017_05_26'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.AssistantUsername, ApiKeys.AssistantPassword)
                                .DeleteAsync($"{ApiKeys.AssistantEndpoint}{workspaceId}/intents/{intent}")
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

        public IntentExport GetIntent(string workspaceId, string intent, bool? export = null)
        {
            if (string.IsNullOrEmpty(workspaceId))
                throw new ArgumentNullException(nameof(workspaceId));
            if (string.IsNullOrEmpty(intent))
                throw new ArgumentNullException(nameof(intent));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'CONVERSATION_VERSION_DATE_2017_05_26'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.AssistantUsername, ApiKeys.AssistantPassword)
                                .GetAsync($"{ApiKeys.AssistantEndpoint}{workspaceId}/intents/{intent}")
                                .WithArgument("version", versionDate)
                                .WithArgument("export", export)
                                .As<IntentExport>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public IntentCollection ListIntents(string workspaceId, bool? export = null, long? pageLimit = null, bool? includeCount = null, string sort = null, string cursor = null)
        {
            if (string.IsNullOrEmpty(workspaceId))
                throw new ArgumentNullException(nameof(workspaceId));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'CONVERSATION_VERSION_DATE_2017_05_26'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.AssistantUsername, ApiKeys.AssistantPassword)
                                .GetAsync($"{ApiKeys.AssistantEndpoint}{workspaceId}/intents")
                                .WithArgument("version", versionDate)
                                .WithArgument("export", export)
                                .WithArgument("page_limit", pageLimit)
                                .WithArgument("include_count", includeCount)
                                .WithArgument("sort", sort)
                                .WithArgument("cursor", cursor)
                                .As<IntentCollection>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public Intent UpdateIntent(string workspaceId, string intent, UpdateIntent body)
        {
            if (string.IsNullOrEmpty(workspaceId))
                throw new ArgumentNullException(nameof(workspaceId));
            if (string.IsNullOrEmpty(intent))
                throw new ArgumentNullException(nameof(intent));
            if (body == null)
                throw new ArgumentNullException(nameof(body));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'CONVERSATION_VERSION_DATE_2017_05_26'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.AssistantUsername, ApiKeys.AssistantPassword)
                                .PostAsync($"{ApiKeys.AssistantEndpoint}{workspaceId}/intents/{intent}")
                                .WithArgument("version", versionDate)
                                .WithBody<UpdateIntent>(body)
                                .As<Intent>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }
        public Example CreateExample(string workspaceId, string intent, CreateExample body)
        {
            if (string.IsNullOrEmpty(workspaceId))
                throw new ArgumentNullException(nameof(workspaceId));
            if (string.IsNullOrEmpty(intent))
                throw new ArgumentNullException(nameof(intent));
            if (body == null)
                throw new ArgumentNullException(nameof(body));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'CONVERSATION_VERSION_DATE_2017_05_26'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.AssistantUsername, ApiKeys.AssistantPassword)
                                .PostAsync($"{ApiKeys.AssistantEndpoint}{workspaceId}/intents/{intent}/examples")
                                .WithArgument("version", versionDate)
                                .WithBody<CreateExample>(body)
                                .As<Example>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public object DeleteExample(string workspaceId, string intent, string text)
        {
            if (string.IsNullOrEmpty(workspaceId))
                throw new ArgumentNullException(nameof(workspaceId));
            if (string.IsNullOrEmpty(intent))
                throw new ArgumentNullException(nameof(intent));
            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException(nameof(text));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'CONVERSATION_VERSION_DATE_2017_05_26'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.AssistantUsername, ApiKeys.AssistantPassword)
                                .DeleteAsync($"{ApiKeys.AssistantEndpoint}{workspaceId}/intents/{intent}/examples/{text}")
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

        public Example GetExample(string workspaceId, string intent, string text)
        {
            if (string.IsNullOrEmpty(workspaceId))
                throw new ArgumentNullException(nameof(workspaceId));
            if (string.IsNullOrEmpty(intent))
                throw new ArgumentNullException(nameof(intent));
            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException(nameof(text));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'CONVERSATION_VERSION_DATE_2017_05_26'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.AssistantUsername, ApiKeys.AssistantPassword)
                                .GetAsync($"{ApiKeys.AssistantEndpoint}{workspaceId}/intents/{intent}/examples/{text}")
                                .WithArgument("version", versionDate)
                                .As<Example>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public ExampleCollection ListExamples(string workspaceId, string intent, long? pageLimit = null, bool? includeCount = null, string sort = null, string cursor = null)
        {
            if (string.IsNullOrEmpty(workspaceId))
                throw new ArgumentNullException(nameof(workspaceId));
            if (string.IsNullOrEmpty(intent))
                throw new ArgumentNullException(nameof(intent));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'CONVERSATION_VERSION_DATE_2017_05_26'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.AssistantUsername, ApiKeys.AssistantPassword)
                                .GetAsync($"{ApiKeys.AssistantEndpoint}{workspaceId}/intents/{intent}/examples")
                                .WithArgument("version", versionDate)
                                .WithArgument("page_limit", pageLimit)
                                .WithArgument("include_count", includeCount)
                                .WithArgument("sort", sort)
                                .WithArgument("cursor", cursor)
                                .As<ExampleCollection>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public Example UpdateExample(string workspaceId, string intent, string text, UpdateExample body)
        {
            if (string.IsNullOrEmpty(workspaceId))
                throw new ArgumentNullException(nameof(workspaceId));
            if (string.IsNullOrEmpty(intent))
                throw new ArgumentNullException(nameof(intent));
            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException(nameof(text));
            if (body == null)
                throw new ArgumentNullException(nameof(body));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'CONVERSATION_VERSION_DATE_2017_05_26'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.AssistantUsername, ApiKeys.AssistantPassword)
                                .PostAsync($"{ApiKeys.AssistantEndpoint}{workspaceId}/intents/{intent}/examples/{text}")
                                .WithArgument("version", versionDate)
                                .WithBody<UpdateExample>(body)
                                .As<Example>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }
        public Entity CreateEntity(string workspaceId, CreateEntity properties)
        {
            if (string.IsNullOrEmpty(workspaceId))
                throw new ArgumentNullException(nameof(workspaceId));
            if (properties == null)
                throw new ArgumentNullException(nameof(properties));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'CONVERSATION_VERSION_DATE_2017_05_26'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.AssistantUsername, ApiKeys.AssistantPassword)
                                .PostAsync($"{ApiKeys.AssistantEndpoint}{workspaceId}/entities")
                                .WithArgument("version", versionDate)
                                .WithBody<CreateEntity>(properties)
                                .As<Entity>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public object DeleteEntity(string workspaceId, string entity)
        {
            if (string.IsNullOrEmpty(workspaceId))
                throw new ArgumentNullException(nameof(workspaceId));
            if (string.IsNullOrEmpty(entity))
                throw new ArgumentNullException(nameof(entity));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'CONVERSATION_VERSION_DATE_2017_05_26'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.AssistantUsername, ApiKeys.AssistantPassword)
                                .DeleteAsync($"{ApiKeys.AssistantEndpoint}{workspaceId}/entities/{entity}")
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

        public EntityExport GetEntity(string workspaceId, string entity, bool? export = null)
        {
            if (string.IsNullOrEmpty(workspaceId))
                throw new ArgumentNullException(nameof(workspaceId));
            if (string.IsNullOrEmpty(entity))
                throw new ArgumentNullException(nameof(entity));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'CONVERSATION_VERSION_DATE_2017_05_26'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.AssistantUsername, ApiKeys.AssistantPassword)
                                .GetAsync($"{ApiKeys.AssistantEndpoint}{workspaceId}/entities/{entity}")
                                .WithArgument("version", versionDate)
                                .WithArgument("export", export)
                                .As<EntityExport>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public EntityCollection ListEntities(string workspaceId, bool? export = null, long? pageLimit = null, bool? includeCount = null, string sort = null, string cursor = null)
        {
            if (string.IsNullOrEmpty(workspaceId))
                throw new ArgumentNullException(nameof(workspaceId));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'CONVERSATION_VERSION_DATE_2017_05_26'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.AssistantUsername, ApiKeys.AssistantPassword)
                                .GetAsync($"{ApiKeys.AssistantEndpoint}{workspaceId}/entities")
                                .WithArgument("version", versionDate)
                                .WithArgument("export", export)
                                .WithArgument("page_limit", pageLimit)
                                .WithArgument("include_count", includeCount)
                                .WithArgument("sort", sort)
                                .WithArgument("cursor", cursor)
                                .As<EntityCollection>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public Entity UpdateEntity(string workspaceId, string entity, UpdateEntity properties)
        {
            if (string.IsNullOrEmpty(workspaceId))
                throw new ArgumentNullException(nameof(workspaceId));
            if (string.IsNullOrEmpty(entity))
                throw new ArgumentNullException(nameof(entity));
            if (properties == null)
                throw new ArgumentNullException(nameof(properties));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'CONVERSATION_VERSION_DATE_2017_05_26'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.AssistantUsername, ApiKeys.AssistantPassword)
                                .PostAsync($"{ApiKeys.AssistantEndpoint}{workspaceId}/entities/{entity}")
                                .WithArgument("version", versionDate)
                                .WithBody<UpdateEntity>(properties)
                                .As<Entity>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }
        public Value CreateValue(string workspaceId, string entity, CreateValue body)
        {
            if (string.IsNullOrEmpty(workspaceId))
                throw new ArgumentNullException(nameof(workspaceId));
            if (string.IsNullOrEmpty(entity))
                throw new ArgumentNullException(nameof(entity));
            if (body == null)
                throw new ArgumentNullException(nameof(body));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'CONVERSATION_VERSION_DATE_2017_05_26'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.AssistantUsername, ApiKeys.AssistantPassword)
                                .PostAsync($"{ApiKeys.AssistantEndpoint}{workspaceId}/entities/{entity}/values")
                                .WithArgument("version", versionDate)
                                .WithBody<CreateValue>(body)
                                .As<Value>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public object DeleteValue(string workspaceId, string entity, string value)
        {
            if (string.IsNullOrEmpty(workspaceId))
                throw new ArgumentNullException(nameof(workspaceId));
            if (string.IsNullOrEmpty(entity))
                throw new ArgumentNullException(nameof(entity));
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'CONVERSATION_VERSION_DATE_2017_05_26'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.AssistantUsername, ApiKeys.AssistantPassword)
                                .DeleteAsync($"{ApiKeys.AssistantEndpoint}{workspaceId}/entities/{entity}/values/{value}")
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

        public ValueExport GetValue(string workspaceId, string entity, string value, bool? export = null)
        {
            if (string.IsNullOrEmpty(workspaceId))
                throw new ArgumentNullException(nameof(workspaceId));
            if (string.IsNullOrEmpty(entity))
                throw new ArgumentNullException(nameof(entity));
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'CONVERSATION_VERSION_DATE_2017_05_26'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.AssistantUsername, ApiKeys.AssistantPassword)
                                .GetAsync($"{ApiKeys.AssistantEndpoint}{workspaceId}/entities/{entity}/values/{value}")
                                .WithArgument("version", versionDate)
                                .WithArgument("export", export)
                                .As<ValueExport>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public ValueCollection ListValues(string workspaceId, string entity, bool? export = null, long? pageLimit = null, bool? includeCount = null, string sort = null, string cursor = null)
        {
            if (string.IsNullOrEmpty(workspaceId))
                throw new ArgumentNullException(nameof(workspaceId));
            if (string.IsNullOrEmpty(entity))
                throw new ArgumentNullException(nameof(entity));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'CONVERSATION_VERSION_DATE_2017_05_26'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.AssistantUsername, ApiKeys.AssistantPassword)
                                .GetAsync($"{ApiKeys.AssistantEndpoint}{workspaceId}/entities/{entity}/values")
                                .WithArgument("version", versionDate)
                                .WithArgument("export", export)
                                .WithArgument("page_limit", pageLimit)
                                .WithArgument("include_count", includeCount)
                                .WithArgument("sort", sort)
                                .WithArgument("cursor", cursor)
                                .As<ValueCollection>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public Value UpdateValue(string workspaceId, string entity, string value, UpdateValue body)
        {
            if (string.IsNullOrEmpty(workspaceId))
                throw new ArgumentNullException(nameof(workspaceId));
            if (string.IsNullOrEmpty(entity))
                throw new ArgumentNullException(nameof(entity));
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            if (body == null)
                throw new ArgumentNullException(nameof(body));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'CONVERSATION_VERSION_DATE_2017_05_26'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.AssistantUsername, ApiKeys.AssistantPassword)
                                .PostAsync($"{ApiKeys.AssistantEndpoint}{workspaceId}/entities/{entity}/values/{value}")
                                .WithArgument("version", versionDate)
                                .WithBody<UpdateValue>(body)
                                .As<Value>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }
        public Synonym CreateSynonym(string workspaceId, string entity, string value, CreateSynonym body)
        {
            if (string.IsNullOrEmpty(workspaceId))
                throw new ArgumentNullException(nameof(workspaceId));
            if (string.IsNullOrEmpty(entity))
                throw new ArgumentNullException(nameof(entity));
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            if (body == null)
                throw new ArgumentNullException(nameof(body));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'CONVERSATION_VERSION_DATE_2017_05_26'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.AssistantUsername, ApiKeys.AssistantPassword)
                                .PostAsync($"{ApiKeys.AssistantEndpoint}{workspaceId}/entities/{entity}/values/{value}/synonyms")
                                .WithArgument("version", versionDate)
                                .WithBody<CreateSynonym>(body)
                                .As<Synonym>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public object DeleteSynonym(string workspaceId, string entity, string value, string synonym)
        {
            if (string.IsNullOrEmpty(workspaceId))
                throw new ArgumentNullException(nameof(workspaceId));
            if (string.IsNullOrEmpty(entity))
                throw new ArgumentNullException(nameof(entity));
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            if (string.IsNullOrEmpty(synonym))
                throw new ArgumentNullException(nameof(synonym));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'CONVERSATION_VERSION_DATE_2017_05_26'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.AssistantUsername, ApiKeys.AssistantPassword)
                                .DeleteAsync($"{ApiKeys.AssistantEndpoint}{workspaceId}/entities/{entity}/values/{value}/synonyms/{synonym}")
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

        public Synonym GetSynonym(string workspaceId, string entity, string value, string synonym)
        {
            if (string.IsNullOrEmpty(workspaceId))
                throw new ArgumentNullException(nameof(workspaceId));
            if (string.IsNullOrEmpty(entity))
                throw new ArgumentNullException(nameof(entity));
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            if (string.IsNullOrEmpty(synonym))
                throw new ArgumentNullException(nameof(synonym));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'CONVERSATION_VERSION_DATE_2017_05_26'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.AssistantUsername, ApiKeys.AssistantPassword)
                                .GetAsync($"{ApiKeys.AssistantEndpoint}{workspaceId}/entities/{entity}/values/{value}/synonyms/{synonym}")
                                .WithArgument("version", versionDate)
                                .As<Synonym>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public SynonymCollection ListSynonyms(string workspaceId, string entity, string value, long? pageLimit = null, bool? includeCount = null, string sort = null, string cursor = null)
        {
            if (string.IsNullOrEmpty(workspaceId))
                throw new ArgumentNullException(nameof(workspaceId));
            if (string.IsNullOrEmpty(entity))
                throw new ArgumentNullException(nameof(entity));
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'CONVERSATION_VERSION_DATE_2017_05_26'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.AssistantUsername, ApiKeys.AssistantPassword)
                                .GetAsync($"{ApiKeys.AssistantEndpoint}{workspaceId}/entities/{entity}/values/{value}/synonyms")
                                .WithArgument("version", versionDate)
                                .WithArgument("page_limit", pageLimit)
                                .WithArgument("include_count", includeCount)
                                .WithArgument("sort", sort)
                                .WithArgument("cursor", cursor)
                                .As<SynonymCollection>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public Synonym UpdateSynonym(string workspaceId, string entity, string value, string synonym, UpdateSynonym body)
        {
            if (string.IsNullOrEmpty(workspaceId))
                throw new ArgumentNullException(nameof(workspaceId));
            if (string.IsNullOrEmpty(entity))
                throw new ArgumentNullException(nameof(entity));
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            if (string.IsNullOrEmpty(synonym))
                throw new ArgumentNullException(nameof(synonym));
            if (body == null)
                throw new ArgumentNullException(nameof(body));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'CONVERSATION_VERSION_DATE_2017_05_26'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.AssistantUsername, ApiKeys.AssistantPassword)
                                .PostAsync($"{ApiKeys.AssistantEndpoint}{workspaceId}/entities/{entity}/values/{value}/synonyms/{synonym}")
                                .WithArgument("version", versionDate)
                                .WithBody<UpdateSynonym>(body)
                                .As<Synonym>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }
        public DialogNode CreateDialogNode(string workspaceId, CreateDialogNode properties)
        {
            if (string.IsNullOrEmpty(workspaceId))
                throw new ArgumentNullException(nameof(workspaceId));
            if (properties == null)
                throw new ArgumentNullException(nameof(properties));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'CONVERSATION_VERSION_DATE_2017_05_26'");
            
            try
            {
               var  result = RepositoryClient.WithAuthentication(ApiKeys.AssistantUsername, ApiKeys.AssistantPassword)
                                .PostAsync($"{ApiKeys.AssistantEndpoint}{workspaceId}/dialog_nodes")
                                .WithArgument("version", versionDate)
                                .WithBody<CreateDialogNode>(properties)
                                .As<DialogNode>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public object DeleteDialogNode(string workspaceId, string dialogNode)
        {
            if (string.IsNullOrEmpty(workspaceId))
                throw new ArgumentNullException(nameof(workspaceId));
            if (string.IsNullOrEmpty(dialogNode))
                throw new ArgumentNullException(nameof(dialogNode));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'CONVERSATION_VERSION_DATE_2017_05_26'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.AssistantUsername, ApiKeys.AssistantPassword)
                                .DeleteAsync($"{ApiKeys.AssistantEndpoint}{workspaceId}/dialogNodes/{dialogNode}")
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

        public DialogNode GetDialogNode(string workspaceId, string dialogNode)
        {
            if (string.IsNullOrEmpty(workspaceId))
                throw new ArgumentNullException(nameof(workspaceId));
            if (string.IsNullOrEmpty(dialogNode))
                throw new ArgumentNullException(nameof(dialogNode));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'CONVERSATION_VERSION_DATE_2017_05_26'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.AssistantUsername, ApiKeys.AssistantPassword)
                                .GetAsync($"{ApiKeys.AssistantEndpoint}{workspaceId}/dialogNodes/{dialogNode}")
                                .WithArgument("version", versionDate)
                                .As<DialogNode>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public DialogNodeCollection ListDialogNodes(string workspaceId, long? pageLimit = null, bool? includeCount = null, string sort = null, string cursor = null)
        {
            if (string.IsNullOrEmpty(workspaceId))
                throw new ArgumentNullException(nameof(workspaceId));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'CONVERSATION_VERSION_DATE_2017_05_26'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.AssistantUsername, ApiKeys.AssistantPassword)
                                .GetAsync($"{ApiKeys.AssistantEndpoint}{workspaceId}/dialog_nodes")
                                .WithArgument("version", versionDate)
                                .WithArgument("page_limit", pageLimit)
                                .WithArgument("include_count", includeCount)
                                .WithArgument("sort", sort)
                                .WithArgument("cursor", cursor)
                                .As<DialogNodeCollection>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public DialogNode UpdateDialogNode(string workspaceId, string dialogNode, UpdateDialogNode properties)
        {
            if (string.IsNullOrEmpty(workspaceId))
                throw new ArgumentNullException(nameof(workspaceId));
            if (string.IsNullOrEmpty(dialogNode))
                throw new ArgumentNullException(nameof(dialogNode));
            if (properties == null)
                throw new ArgumentNullException(nameof(properties));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'CONVERSATION_VERSION_DATE_2017_05_26'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.AssistantUsername, ApiKeys.AssistantPassword)
                                .PostAsync($"{ApiKeys.AssistantEndpoint}{workspaceId}/dialogNodes/{dialogNode}")
                                .WithArgument("version", versionDate)
                                .WithBody<UpdateDialogNode>(properties)
                                .As<DialogNode>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }
        public LogCollection ListAllLogs(string filter, string sort = null, long? pageLimit = null, string cursor = null)
        {
            if (string.IsNullOrEmpty(filter))
                throw new ArgumentNullException(nameof(filter));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'CONVERSATION_VERSION_DATE_2017_05_26'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.AssistantUsername, ApiKeys.AssistantPassword)
                                .GetAsync($"{ApiKeys.AssistantEndpoint}/v1/logs")
                                .WithArgument("version", versionDate)
                                .WithArgument("filter", filter)
                                .WithArgument("sort", sort)
                                .WithArgument("page_limit", pageLimit)
                                .WithArgument("cursor", cursor)
                                .As<LogCollection>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public LogCollection ListLogs(string workspaceId, string sort = null, string filter = null, long? pageLimit = null, string cursor = null)
        {
            if (string.IsNullOrEmpty(workspaceId))
                throw new ArgumentNullException(nameof(workspaceId));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'CONVERSATION_VERSION_DATE_2017_05_26'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.AssistantUsername, ApiKeys.AssistantPassword)
                                .GetAsync($"{ApiKeys.AssistantEndpoint}{workspaceId}/logs")
                                .WithArgument("version", versionDate)
                                .WithArgument("sort", sort)
                                .WithArgument("filter", filter)
                                .WithArgument("page_limit", pageLimit)
                                .WithArgument("cursor", cursor)
                                .As<LogCollection>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }
        public Counterexample CreateCounterexample(string workspaceId, CreateCounterexample body)
        {
            if (string.IsNullOrEmpty(workspaceId))
                throw new ArgumentNullException(nameof(workspaceId));
            if (body == null)
                throw new ArgumentNullException(nameof(body));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'CONVERSATION_VERSION_DATE_2017_05_26'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.AssistantUsername, ApiKeys.AssistantPassword)
                                .PostAsync($"{ApiKeys.AssistantEndpoint}{workspaceId}/counterexamples")
                                .WithArgument("version", versionDate)
                                .WithBody<CreateCounterexample>(body)
                                .As<Counterexample>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public object DeleteCounterexample(string workspaceId, string text)
        {
            if (string.IsNullOrEmpty(workspaceId))
                throw new ArgumentNullException(nameof(workspaceId));
            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException(nameof(text));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'CONVERSATION_VERSION_DATE_2017_05_26'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.AssistantUsername, ApiKeys.AssistantPassword)
                                .DeleteAsync($"{ApiKeys.AssistantEndpoint}{workspaceId}/counterexamples/{text}")
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

        public Counterexample GetCounterexample(string workspaceId, string text)
        {
            if (string.IsNullOrEmpty(workspaceId))
                throw new ArgumentNullException(nameof(workspaceId));
            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException(nameof(text));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'CONVERSATION_VERSION_DATE_2017_05_26'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.AssistantUsername, ApiKeys.AssistantPassword)
                                .GetAsync($"{ApiKeys.AssistantEndpoint}{workspaceId}/counterexamples/{text}")
                                .WithArgument("version", versionDate)
                                .As<Counterexample>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public CounterexampleCollection ListCounterexamples(string workspaceId, long? pageLimit = null, bool? includeCount = null, string sort = null, string cursor = null)
        {
            if (string.IsNullOrEmpty(workspaceId))
                throw new ArgumentNullException(nameof(workspaceId));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'CONVERSATION_VERSION_DATE_2017_05_26'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.AssistantUsername, ApiKeys.AssistantPassword)
                                .GetAsync($"{ApiKeys.AssistantEndpoint}{workspaceId}/counterexamples")
                                .WithArgument("version", versionDate)
                                .WithArgument("page_limit", pageLimit)
                                .WithArgument("include_count", includeCount)
                                .WithArgument("sort", sort)
                                .WithArgument("cursor", cursor)
                                .As<CounterexampleCollection>()
                                .Result;

                return result;
            }
            catch(AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        public Counterexample UpdateCounterexample(string workspaceId, string text, UpdateCounterexample body)
        {
            if (string.IsNullOrEmpty(workspaceId))
                throw new ArgumentNullException(nameof(workspaceId));
            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException(nameof(text));
            if (body == null)
                throw new ArgumentNullException(nameof(body));
            if(string.IsNullOrEmpty(versionDate))
                throw new ArgumentNullException("versionDate cannot be null. Use 'CONVERSATION_VERSION_DATE_2017_05_26'");
            
            try
            {
                var result = RepositoryClient.WithAuthentication(ApiKeys.AssistantUsername, ApiKeys.AssistantPassword)
                                .PostAsync($"{ApiKeys.AssistantEndpoint}{workspaceId}/counterexamples/{text}")
                                .WithArgument("version", versionDate)
                                .WithBody<UpdateCounterexample>(body)
                                .As<Counterexample>()
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