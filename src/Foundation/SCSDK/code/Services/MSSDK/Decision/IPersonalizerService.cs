using SitecoreCognitiveServices.Foundation.MSSDK.Decision.Models.Personalizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Decision
{
    public interface IPersonalizerService
    {
        RankResponse Rank(RankRequest request);
        ClientConfiguration GetClientConfiguration();
        void Reward(string eventId, float reward);
        void ActivateEvent(string eventId);
        Evaluation SubmitNewEvaluation(EvaluationRequest request);
        Policy DeleteCurrentPolicy();
        void DeleteEvaluation(string evaluationId);
        void DeleteLogs();
        void DeleteModel();
        Policy UpdatePolicyConfiguration(Policy policy);
        AzureService UpdateServiceConfiguration(AzureService config);
        byte[] GetCurrentModel();
        ModelProperties GetModelProperties();
        Evaluation GetEvaluation(string evaluationId);
        Policy GetPolicyConfiguration();
        AzureService GetServiceConfiguration();
        LogsProperties GetLogsProperties();
        List<Evaluation> GetEvaluations();
        Status GetStatus();
    }
}