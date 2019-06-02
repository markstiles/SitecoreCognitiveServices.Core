using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.NexSDK.Contest;
using SitecoreCognitiveServices.Foundation.NexSDK.Contest.Models;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.NexSDK
{
    public class ContestService : IContestService
    {
        protected readonly IContestRepository ContestRepository;
        protected readonly ILogWrapper Logger;
        
        public ContestService(
            IContestRepository contestRepository,
            ILogWrapper logger)
        {
            ContestRepository = contestRepository;
            Logger = logger;
        }

        public virtual Task<ContestResponse> GetContest(Guid sessionId)
        {
            try
            {
                var result = ContestRepository.GetContest(sessionId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ContestService.GetContest failed", this, ex);
            }

            return null;
        }

        public virtual Task<ContestantResponse> GetChampion(Guid sessionId, ChampionQueryOptions options = null)
        {
            try
            {
                var result = ContestRepository.GetChampion(sessionId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ContestService.GetChampion failed", this, ex);
            }

            return null;
        }

        public virtual Task<ContestSelectionResponse> GetSelection(Guid sessionId)
        {
            try
            {
                var result = ContestRepository.GetSelection(sessionId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ContestService.GetSelection failed", this, ex);
            }

            return null;
        }

        public virtual Task<ChampionContestantList> ListContestants(Guid sessionId)
        {
            try
            {
                var result = ContestRepository.ListContestants(sessionId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ContestService.ListContestants failed", this, ex);
            }

            return null;
        }

        public virtual Task<ContestantResponse> GetContestant(Guid sessionId, string contestantId, ChampionQueryOptions options = null)
        {
            try
            {
                var result = ContestRepository.GetContestant(sessionId, contestantId, options);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ContestService.GetContestant failed", this, ex);
            }

            return null;
        }
    }
}