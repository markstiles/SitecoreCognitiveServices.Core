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
        void RewardTopRankedAction(string eventId);
        void ActivateEvent(string eventId);
        Evaluation SubmitNewEvaluation(EvaluationRequest request);
        Policy DeleteCurrentPolicy();
        void DeleteEvaluation(string evaluationId);
        void DeleteLogs();
        void DeleteModel();
        Policy UpdatePolicyConfiguration(Policy policy);
        Service UpdateServiceConfiguration(Service config);
        byte[] GetCurrentModel();
        ModelProperties GetModelProperties();
        Evaluation GetEvaluation(string evaluationId);
        Policy GetPolicyConfiguration();
        Service GetServiceConfiguration();
        LogsProperties GetLogsProperties();
        List<Evaluation> GetEvaluations();
        Status GetStatus();
    }
}