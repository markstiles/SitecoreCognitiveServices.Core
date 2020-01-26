using SitecoreCognitiveServices.Foundation.MSSDK;
using SitecoreCognitiveServices.Foundation.MSSDK.Decision;
using SitecoreCognitiveServices.Foundation.MSSDK.Decision.Models.Personalizer;
using SitecoreCognitiveServices.Foundation.SCSDK.RetryPolicies;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Decision
{
    public class PersonalizerService : IPersonalizerService
    {
        protected readonly IMicrosoftCognitiveServicesApiKeys ApiKeys;
        protected readonly IMSSDKPolicyService PolicyService;
        protected readonly IPersonalizerRepository Repository;
        protected readonly ILogWrapper Logger;

        public PersonalizerService(
            IMicrosoftCognitiveServicesApiKeys apiKeys,
            IMSSDKPolicyService policyService,
            IPersonalizerRepository repository,
            ILogWrapper logger)
        {
            ApiKeys = apiKeys;
            PolicyService = policyService;
            Repository = repository;
            Logger = logger;
        }
        
        #region Post

        public RankResponse Rank(RankRequest request)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "PersonalizerService.Rank",
                ApiKeys.PersonalizerRetryInSeconds,
                () =>
                {
                    var result = Repository.Rank(request);
                    return result;
                },
                null);
        }

        public ClientConfiguration GetClientConfiguration()
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                "PersonalizerService.GetClientConfiguration",
                ApiKeys.PersonalizerRetryInSeconds,
                () =>
                {
                    var result = Repository.GetClientConfiguration();
                    return result;
                },
                null);
        }

        public void Reward(string eventId, float reward)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                   "PersonalizerService.Reward",
                   ApiKeys.PersonalizerRetryInSeconds,
                   () =>
                   {
                       Repository.Reward(eventId, reward);
                       return true;
                   },
                   false);
        }

        public void ActivateEvent(string eventId)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                   "PersonalizerService.ActivateEvent",
                   ApiKeys.PersonalizerRetryInSeconds,
                   () =>
                   {
                       Repository.ActivateEvent(eventId);
                       return true;
                   },
                   false);
        }

        public Evaluation SubmitNewEvaluation(EvaluationRequest request)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                   "PersonalizerService.SubmitNewEvaluation",
                   ApiKeys.PersonalizerRetryInSeconds,
                   () =>
                   {
                       var result = Repository.SubmitNewEvaluation(request);
                       return result;
                   },
                   null);
        }

        #endregion Post

        #region Delete

        public Policy DeleteCurrentPolicy()
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                   "PersonalizerService.DeleteCurrentPolicy",
                   ApiKeys.PersonalizerRetryInSeconds,
                   () =>
                   {
                       var result = Repository.DeleteCurrentPolicy();
                       return result;
                   },
                   null);
        }

        public void DeleteEvaluation(string evaluationId)
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                   "PersonalizerService.DeleteEvaluation",
                   ApiKeys.PersonalizerRetryInSeconds,
                   () =>
                   {
                       Repository.DeleteEvaluation(evaluationId);
                       return true;
                   },
                   false);
        }

        public void DeleteLogs()
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                   "PersonalizerService.DeleteLogs",
                   ApiKeys.PersonalizerRetryInSeconds,
                   () =>
                   {
                       Repository.DeleteLogs();
                       return true;
                   },
                   false);
        }

        public void DeleteModel()
        {
            PolicyService.ExecuteRetryAndCapture400Errors(
                   "PersonalizerService.DeleteModel",
                   ApiKeys.PersonalizerRetryInSeconds,
                   () =>
                   {
                       Repository.DeleteModel();
                       return true;
                   },
                   false);
        }

        #endregion Delete

        #region Update

        public Policy UpdatePolicyConfiguration(Policy policy)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                   "PersonalizerService.UpdatePolicyConfiguration",
                   ApiKeys.PersonalizerRetryInSeconds,
                   () =>
                   {
                       var result = Repository.UpdatePolicyConfiguration(policy);
                       return result;
                   },
                   null);
        }

        public AzureService UpdateServiceConfiguration(AzureService config)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                   "PersonalizerService.UpdateServiceConfiguration",
                   ApiKeys.PersonalizerRetryInSeconds,
                   () =>
                   {
                       var result = Repository.UpdateServiceConfiguration(config);
                       return result;
                   },
                   null);
        }

        #endregion Update

        #region Get

        public byte[] GetCurrentModel()
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                   "PersonalizerService.GetCurrentModel",
                   ApiKeys.PersonalizerRetryInSeconds,
                   () =>
                   {
                       var result = Repository.GetCurrentModel();
                       return result;
                   },
                   null);
        }

        public ModelProperties GetModelProperties()
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                   "PersonalizerService.GetModelProperties",
                   ApiKeys.PersonalizerRetryInSeconds,
                   () =>
                   {
                       var result = Repository.GetModelProperties();
                       return result;
                   },
                   null);
        }

        public Evaluation GetEvaluation(string evaluationId)
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                   "PersonalizerService.GetEvaluation",
                   ApiKeys.PersonalizerRetryInSeconds,
                   () =>
                   {
                       var result = Repository.GetEvaluation(evaluationId);
                       return result;
                   },
                   null);
        }

        public Policy GetPolicyConfiguration()
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                   "PersonalizerService.GetPolicyConfiguration",
                   ApiKeys.PersonalizerRetryInSeconds,
                   () =>
                   {
                       var result = Repository.GetPolicyConfiguration();
                       return result;
                   },
                   null);
        }

        public AzureService GetServiceConfiguration()
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                   "PersonalizerService.GetServiceConfiguration",
                   ApiKeys.PersonalizerRetryInSeconds,
                   () =>
                   {
                       var result = Repository.GetServiceConfiguration();
                       return result;
                   },
                   null);
        }

        public LogsProperties GetLogsProperties()
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                   "PersonalizerService.GetLogsProperties",
                   ApiKeys.PersonalizerRetryInSeconds,
                   () =>
                   {
                       var result = Repository.GetLogsProperties();
                       return result;
                   },
                   null);
        }

        public List<Evaluation> GetEvaluations()
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                   "PersonalizerService.GetEvaluations",
                   ApiKeys.PersonalizerRetryInSeconds,
                   () =>
                   {
                       var result = Repository.GetEvaluations();
                       return result;
                   },
                   null);
        }

        public Status GetStatus()
        {
            return PolicyService.ExecuteRetryAndCapture400Errors(
                   "PersonalizerService.GetStatus",
                   ApiKeys.PersonalizerRetryInSeconds,
                   () =>
                   {
                       var result = Repository.GetStatus();
                       return result;
                   },
                   null);
        }

        #endregion Get
    }
}