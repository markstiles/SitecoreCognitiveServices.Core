using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sitecore.Reflection.Emit;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.NexSDK.Account;
using SitecoreCognitiveServices.Foundation.NexSDK.Account.Models;
using SitecoreCognitiveServices.Foundation.NexSDK.Session;
using SitecoreCognitiveServices.Foundation.NexSDK.Session.Models;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.NexSDK
{
    public class SessionService : ISessionService
    {
        protected readonly ISessionRepository SessionRepository;
        protected readonly ILogWrapper Logger;
        
        public SessionService(
            ISessionRepository sessionRepository,
            ILogWrapper logger)
        {
            SessionRepository = sessionRepository;
            Logger = logger;
        }

        public async Task<SessionResponse> CreateForecast(ForecastSessionRequest request)
        {
            try
            {
                var result = await SessionRepository.CreateForecast(request);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SessionService.CreateForecast failed", this, ex);
            }

            return null;
        }

        public async Task<SessionResponse> AnalyzeImpact(ImpactSessionRequest request)
        {
            try
            {
                var result = await SessionRepository.AnalyzeImpact(request);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SessionService.AnalyzeImpact failed", this, ex);
            }

            return null;
        }

        public async Task<SessionResponse> TrainModel(ModelSessionRequest request)
        {
            try
            {
                var result = await SessionRepository.TrainModel(request);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SessionService.TrainModel failed", this, ex);
            }

            return null;
        }

        public async Task<SessionResponseList> List(SessionQuery query = null)
        {
            try
            {
                var result = await SessionRepository.List(query);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SessionService.List failed", this, ex);
            }

            return null;
        }

        public async Task Remove(SessionRemoveCriteria criteria)
        {
            try
            {
                SessionRepository.Remove(criteria);
            }
            catch (Exception ex)
            {
                Logger.Error("SessionService.Remove failed", this, ex);
            }
        }

        public async Task<SessionResponse> Get(Guid id)
        {
            try
            {
                var result = await SessionRepository.Get(id);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SessionService.Get failed", this, ex);
            }

            return null;
        }

        public async Task<SessionResultStatus> GetStatus(Guid id)
        {
            try
            {
                var result = await SessionRepository.GetStatus(id);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SessionService.GetStatus failed", this, ex);
            }

            return null;
        }

        public async Task Remove(Guid id)
        {
            try
            {
                SessionRepository.Remove(id);
            }
            catch (Exception ex)
            {
                Logger.Error("SessionService.Remove failed", this, ex);
            }
        }

        public async Task<SessionResult> GetResults(Guid id, SessionResultsQuery query = null)
        {
            try
            {
                var result = await SessionRepository.GetResults(id, query);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SessionService.GetResults failed", this, ex);
            }

            return null;
        }

        public async Task<ConfusionMatrixResult> GetResultConfusionMatrix(Guid id)
        {
            try
            {
                var result = await SessionRepository.GetResultConfusionMatrix(id);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SessionService.GetResultConfusionMatrix failed", this, ex);
            }

            return null;
        }

        public async Task<SessionResult> GetResultAnomalyScores(Guid id)
        {
            try
            {
                var result = await SessionRepository.GetResultAnomalyScores(id);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SessionService.GetResultAnomalyScores failed", this, ex);
            }

            return null;
        }

        public async Task<SessionResult> GetResultClassScores(Guid id)
        {
            try
            {
                var result = await SessionRepository.GetResultClassScores(id);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SessionService.GetResultClassScores failed", this, ex);
            }

            return null;
        }
    }
}