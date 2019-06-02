using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK
{
    public partial class Client
    {
        /// <summary>
        /// Create a new prediction.
        /// </summary>
        [System.Obsolete("Create is deprecated, use CreatePrediction instead.")]
        public Task<Prediction> Create(Prediction.Arguments arguments)
        {
            return CreatePrediction(arguments);
        }

        /// <summary>
        /// Create a new prediction.
        /// </summary>
        public Task<Prediction> CreatePrediction(Prediction.Arguments arguments)
        {
            return Create<Prediction>(arguments);
        }

        /// <summary>
        /// Create a new prediction.
        /// </summary>
        /// <param name="model">A valid Model</param>
        /// <param name="name">The name you want to give to the new prediction. </param>
        [System.Obsolete("Create is deprecated, use CreatePrediction instead.")]
        public Task<Prediction> Create(Model model, string name = null, Prediction.Arguments arguments = null)
        {
            return CreatePrediction(model, name, arguments);
        }

        /// <summary>
        /// Create a new prediction.
        /// </summary>
        /// <param name="model">A valid Model</param>
        /// <param name="name">The name you want to give to the new prediction. </param>
        public Task<Prediction> CreatePrediction(Model model, string name = null, Prediction.Arguments arguments = null)
        {
            arguments = arguments ?? new Prediction.Arguments();
            if (!string.IsNullOrWhiteSpace(name)) arguments.Name = name;
            arguments.Model = model.Resource;
            return Create<Prediction>(arguments);
        }

        public Query<Prediction.Filterable, Prediction.Orderable, Prediction> ListPredictions()
        {
            return new PredictionListing(List<Prediction>);
        }
    }
}