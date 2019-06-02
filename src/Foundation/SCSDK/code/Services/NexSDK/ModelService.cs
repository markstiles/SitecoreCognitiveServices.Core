using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.NexSDK.Model;
using SitecoreCognitiveServices.Foundation.NexSDK.Model.Models;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.NexSDK
{
    public class ModelService : IModelService
    {
        protected readonly IModelRepository ModelRepository;
        protected readonly ILogWrapper Logger;
        
        public ModelService(
            IModelRepository modelRepository,
            ILogWrapper logger)
        {
            ModelRepository = modelRepository;
            Logger = logger;
        }

        public async Task<ModelSummary> Get(Guid id)
        {
            try
            {
                var result = await ModelRepository.Get(id);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ModelService.Get failed", this, ex);
            }

            return null;
        }

        public async Task<ModelSummaryList> List(ModelSummaryQuery query = null)
        {
            try
            {
                var result = await ModelRepository.List(query);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ModelService.List failed", this, ex);
            }

            return null;
        }

        public async Task<ModelPredictionResult> Predict(ModelPredictionRequest request)
        {
            try
            {
                var result = await ModelRepository.Predict(request);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ModelService.Predict failed", this, ex);
            }

            return null;
        }

        public async Task Remove(ModelRemoveCriteria criteria)
        {
            try
            {
                ModelRepository.Remove(criteria);
            }
            catch (Exception ex)
            {
                Logger.Error("ModelService.Remove failed", this, ex);
            }
        }
    }
}