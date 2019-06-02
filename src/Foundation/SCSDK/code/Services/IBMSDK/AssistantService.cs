using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.IBMSDK.Assistant;
using SitecoreCognitiveServices.Foundation.IBMSDK.Assistant.Models;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.IBMSDK
{
    public class AssistantService : IAssistantService
    {
        protected IAssistantRepository AssistantRepository;
        protected ILogWrapper Logger;

        public AssistantService(
            IAssistantRepository assistantRepository,
            ILogWrapper logger)
        {
            AssistantRepository = assistantRepository;
            Logger = logger;
        }
        
        public Workspace CreateWorkspace(CreateWorkspace properties = null)
        {
            try
            {
                var result = AssistantRepository.CreateWorkspace(properties);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AssistantService.CreateWorkspace failed", this, ex);
            }

            return null;
        }

        public object DeleteWorkspace(string workspaceId)
        {
            try
            {
                var result = AssistantRepository.DeleteWorkspace(workspaceId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AssistantService.DeleteWorkspace failed", this, ex);
            }

            return null;
        }

        public WorkspaceExport GetWorkspace(string workspaceId, bool? export = null)
        {
            try
            {
                var result = AssistantRepository.GetWorkspace(workspaceId, export);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AssistantService.GetWorkspace failed", this, ex);
            }

            return null;
        }

        public WorkspaceCollection ListWorkspaces(long? pageLimit = null, bool? includeCount = null, string sort = null, string cursor = null)
        {
            try
            {
                var result = AssistantRepository.ListWorkspaces(pageLimit, includeCount, sort, cursor);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AssistantService.ListWorkspaces failed", this, ex);
            }

            return null;
        }

        public Workspace UpdateWorkspace(string workspaceId, UpdateWorkspace properties = null, bool? append = null)
        {
            try
            {
                var result = AssistantRepository.UpdateWorkspace(workspaceId, properties, append);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AssistantService.UpdateWorkspace failed", this, ex);
            }

            return null;
        }

        public MessageResponse Message(string workspaceId, MessageRequest request = null)
        {
            try
            {
                var result = AssistantRepository.Message(workspaceId, request);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AssistantService.Message failed", this, ex);
            }

            return null;
        }

        public Intent CreateIntent(string workspaceId, CreateIntent body)
        {
            try
            {
                var result = AssistantRepository.CreateIntent(workspaceId, body);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AssistantService.CreateIntent failed", this, ex);
            }

            return null;
        }

        public object DeleteIntent(string workspaceId, string intent)
        {
            try
            {
                var result = AssistantRepository.DeleteIntent(workspaceId, intent);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AssistantService.DeleteIntent failed", this, ex);
            }

            return null;
        }

        public IntentExport GetIntent(string workspaceId, string intent, bool? export = null)
        {
            try
            {
                var result = AssistantRepository.GetIntent(workspaceId, intent, export);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AssistantService.GetIntent failed", this, ex);
            }

            return null;
        }

        public IntentCollection ListIntents(string workspaceId, bool? export = null, long? pageLimit = null, bool? includeCount = null, string sort = null, string cursor = null)
        {
            try
            {
                var result = AssistantRepository.ListIntents(workspaceId, export, pageLimit, includeCount, sort, cursor);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AssistantService.ListIntents failed", this, ex);
            }

            return null;
        }

        public Intent UpdateIntent(string workspaceId, string intent, UpdateIntent body)
        {
            try
            {
                var result = AssistantRepository.UpdateIntent(workspaceId, intent, body);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AssistantService.UpdateIntent failed", this, ex);
            }

            return null;
        }

        public Example CreateExample(string workspaceId, string intent, CreateExample body)
        {
            try
            {
                var result = AssistantRepository.CreateExample(workspaceId, intent, body);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AssistantService.CreateExample failed", this, ex);
            }

            return null;
        }

        public object DeleteExample(string workspaceId, string intent, string text)
        {
            try
            {
                var result = AssistantRepository.DeleteExample(workspaceId, intent, text);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AssistantService.DeleteExample failed", this, ex);
            }

            return null;
        }

        public Example GetExample(string workspaceId, string intent, string text)
        {
            try
            {
                var result = AssistantRepository.GetExample(workspaceId, intent, text);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AssistantService.GetExample failed", this, ex);
            }

            return null;
        }

        public ExampleCollection ListExamples(string workspaceId, string intent, long? pageLimit = null, bool? includeCount = null, string sort = null, string cursor = null)
        {
            try
            {
                var result = AssistantRepository.ListExamples(workspaceId, intent, pageLimit, includeCount, sort, cursor);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AssistantService.ListExamples failed", this, ex);
            }

            return null;
        }

        public Example UpdateExample(string workspaceId, string intent, string text, UpdateExample body)
        {
            try
            {
                var result = AssistantRepository.UpdateExample(workspaceId, intent, text, body);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AssistantService.UpdateExample failed", this, ex);
            }

            return null;
        }

        public Entity CreateEntity(string workspaceId, CreateEntity properties)
        {
            try
            {
                var result = AssistantRepository.CreateEntity(workspaceId, properties);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AssistantService.CreateEntity failed", this, ex);
            }

            return null;
        }

        public object DeleteEntity(string workspaceId, string entity)
        {
            try
            {
                var result = AssistantRepository.DeleteEntity(workspaceId, entity);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AssistantService.DeleteEntity failed", this, ex);
            }

            return null;
        }

        public EntityExport GetEntity(string workspaceId, string entity, bool? export = null)
        {
            try
            {
                var result = AssistantRepository.GetEntity(workspaceId, entity, export);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AssistantService.GetEntity failed", this, ex);
            }

            return null;
        }

        public EntityCollection ListEntities(string workspaceId, bool? export = null, long? pageLimit = null, bool? includeCount = null, string sort = null, string cursor = null)
        {
            try
            {
                var result = AssistantRepository.ListEntities(workspaceId, export, pageLimit, includeCount, sort, cursor);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AssistantService.ListEntities failed", this, ex);
            }

            return null;
        }

        public Entity UpdateEntity(string workspaceId, string entity, UpdateEntity properties)
        {
            try
            {
                var result = AssistantRepository.UpdateEntity(workspaceId, entity, properties);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AssistantService.UpdateEntity failed", this, ex);
            }

            return null;
        }

        public Value CreateValue(string workspaceId, string entity, CreateValue body)
        {
            try
            {
                var result = AssistantRepository.CreateValue(workspaceId, entity, body);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AssistantService.CreateValue failed", this, ex);
            }

            return null;
        }

        public object DeleteValue(string workspaceId, string entity, string value)
        {
            try
            {
                var result = AssistantRepository.DeleteValue(workspaceId, entity, value);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AssistantService.DeleteValue failed", this, ex);
            }

            return null;
        }

        public ValueExport GetValue(string workspaceId, string entity, string value, bool? export = null)
        {
            try
            {
                var result = AssistantRepository.GetValue(workspaceId, entity, value, export);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AssistantService.GetValue failed", this, ex);
            }

            return null;
        }

        public ValueCollection ListValues(string workspaceId, string entity, bool? export = null, long? pageLimit = null, bool? includeCount = null, string sort = null, string cursor = null)
        {
            try
            {
                var result = AssistantRepository.ListValues(workspaceId, entity, export, pageLimit, includeCount, sort, cursor);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AssistantService.ListValues failed", this, ex);
            }

            return null;
        }

        public Value UpdateValue(string workspaceId, string entity, string value, UpdateValue body)
        {
            try
            {
                var result = AssistantRepository.UpdateValue(workspaceId, entity, value, body);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AssistantService.UpdateValue failed", this, ex);
            }

            return null;
        }

        public Synonym CreateSynonym(string workspaceId, string entity, string value, CreateSynonym body)
        {
            try
            {
                var result = AssistantRepository.CreateSynonym(workspaceId, entity, value, body);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AssistantService.CreateSynonym failed", this, ex);
            }

            return null;
        }

        public object DeleteSynonym(string workspaceId, string entity, string value, string synonym)
        {
            try
            {
                var result = AssistantRepository.DeleteSynonym(workspaceId, entity, value, synonym);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AssistantService.DeleteSynonym failed", this, ex);
            }

            return null;
        }

        public Synonym GetSynonym(string workspaceId, string entity, string value, string synonym)
        {
            try
            {
                var result = AssistantRepository.GetSynonym(workspaceId, entity, value, synonym);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AssistantService.GetSynonym failed", this, ex);
            }

            return null;
        }

        public SynonymCollection ListSynonyms(string workspaceId, string entity, string value, long? pageLimit = null, bool? includeCount = null, string sort = null, string cursor = null)
        {
            try
            {
                var result = AssistantRepository.ListSynonyms(workspaceId, entity, value, pageLimit, includeCount, sort, cursor);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AssistantService.ListSynonyms failed", this, ex);
            }

            return null;
        }

        public Synonym UpdateSynonym(string workspaceId, string entity, string value, string synonym, UpdateSynonym body)
        {
            try
            {
                var result = AssistantRepository.UpdateSynonym(workspaceId, entity, value, synonym, body);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AssistantService.workspaceId failed", this, ex);
            }

            return null;
        }

        public DialogNode CreateDialogNode(string workspaceId, CreateDialogNode properties)
        {
            try
            {
                var result = AssistantRepository.CreateDialogNode(workspaceId, properties);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AssistantService.CreateDialogNode failed", this, ex);
            }

            return null;
        }

        public object DeleteDialogNode(string workspaceId, string dialogNode)
        {
            try
            {
                var result = AssistantRepository.DeleteDialogNode(workspaceId, dialogNode);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AssistantService.DeleteDialogNode failed", this, ex);
            }

            return null;
        }

        public DialogNode GetDialogNode(string workspaceId, string dialogNode)
        {
            try
            {
                var result = AssistantRepository.GetDialogNode(workspaceId, dialogNode);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AssistantService.GetDialogNode failed", this, ex);
            }

            return null;
        }

        public DialogNodeCollection ListDialogNodes(string workspaceId, long? pageLimit = null, bool? includeCount = null, string sort = null, string cursor = null)
        {
            try
            {
                var result = AssistantRepository.ListDialogNodes(workspaceId, pageLimit, includeCount, sort, cursor);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AssistantService.ListDialogNodes failed", this, ex);
            }

            return null;
        }

        public DialogNode UpdateDialogNode(string workspaceId, string dialogNode, UpdateDialogNode properties)
        {
            try
            {
                var result = AssistantRepository.UpdateDialogNode(workspaceId, dialogNode, properties);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AssistantService.UpdateDialogNode failed", this, ex);
            }

            return null;
        }

        public LogCollection ListAllLogs(string filter, string sort = null, long? pageLimit = null, string cursor = null)
        {
            try
            {
                var result = AssistantRepository.ListAllLogs(filter, sort, pageLimit, cursor);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AssistantService.ListAllLogs failed", this, ex);
            }

            return null;
        }

        public LogCollection ListLogs(string workspaceId, string sort = null, string filter = null, long? pageLimit = null, string cursor = null)
        {
            try
            {
                var result = AssistantRepository.ListLogs(workspaceId, sort, filter, pageLimit, cursor);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AssistantService.ListLogs failed", this, ex);
            }

            return null;
        }

        public Counterexample CreateCounterexample(string workspaceId, CreateCounterexample body)
        {
            try
            {
                var result = AssistantRepository.CreateCounterexample(workspaceId, body);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AssistantService.CreateCounterexample failed", this, ex);
            }

            return null;
        }

        public object DeleteCounterexample(string workspaceId, string text)
        {
            try
            {
                var result = AssistantRepository.DeleteCounterexample(workspaceId, text);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AssistantService.DeleteCounterexample failed", this, ex);
            }

            return null;
        }

        public Counterexample GetCounterexample(string workspaceId, string text)
        {
            try
            {
                var result = AssistantRepository.GetCounterexample(workspaceId, text);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AssistantService.GetCounterexample failed", this, ex);
            }

            return null;
        }

        public CounterexampleCollection ListCounterexamples(string workspaceId, long? pageLimit = null, bool? includeCount = null, string sort = null, string cursor = null)
        {
            try
            {
                var result = AssistantRepository.ListCounterexamples(workspaceId, pageLimit, includeCount, sort, cursor);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AssistantService.ListCounterexamples failed", this, ex);
            }

            return null;
        }

        public Counterexample UpdateCounterexample(string workspaceId, string text, UpdateCounterexample body)
        {
            try
            {
                var result = AssistantRepository.UpdateCounterexample(workspaceId, text, body);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("AssistantService.UpdateCounterexample failed", this, ex);
            }

            return null;
        }
    }
}