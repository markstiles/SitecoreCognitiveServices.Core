using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.NexSDK.Http.Models;
using SitecoreCognitiveServices.Foundation.NexSDK.Model.Models;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Model
{
    public interface IModelRepository
    {
        /// <summary>
        /// Gets a model
        /// </summary>
        /// <param name="id">The id of the model.</param>
        /// <exception cref="NexosisClientException">Thrown when 4xx or 5xx response is received from server, or errors in parsing the response.</exception>
        /// <returns>A <see cref="ModelSummary"/> with information about the model.</returns>
        /// <remarks>GET of https://ml.nexosis.com/api/model/{modelId}</remarks>
        Task<ModelSummary> Get(Guid id);

        /// <summary>
        /// Gets the list of all models that have been created.
        /// </summary>
        /// <param name="query">The query criteria for retrieving the models</param>
        /// <exception cref="NexosisClientException">Thrown when 4xx or 5xx response is received from server, or errors in parsing the response.</exception>
        /// <returns>A list of <see cref="ModelSummary"/>.</returns>
        /// <remarks>GET of https://ml.nexosis.com/api/model</remarks>
        Task<ModelSummaryList> List(ModelSummaryQuery query = null);

        /// <summary>
        /// Predicts target values for a set of features using the specified model. 
        /// </summary>
        /// <param name="request">Parameters to be used when predicting from a model</param>
        /// <exception cref="NexosisClientException">Thrown when 4xx or 5xx response is received from server, or errors in parsing the response.</exception>
        /// <returns><see cref="ModelPredictionResult"/> containing the predicted results and features that were sent.</returns>
        /// <remarks>POST of https://ml.nexosis.com/api/model/{modelId}/predict</remarks>
        Task<ModelPredictionResult> Predict(ModelPredictionRequest request);


        /// <summary>
        /// Removes Models from your account which match the specified parameters
        /// </summary>
        /// <param name="criteria">The criteria defining which models to remove</param>
        /// <exception cref="NexosisClientException">Thrown when 4xx or 5xx response is received from server, or errors in parsing the response.</exception>
        /// <remarks>DELETE of https://ml.nexosis.com/api/model</remarks>
        Task Remove(ModelRemoveCriteria criteria);
    }
}