using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.MSSDK.Decision.Models.Personalizer;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Decision
{
    public interface IPersonalizerRepository
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