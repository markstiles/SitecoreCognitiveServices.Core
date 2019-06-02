using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.NexSDK.Account.Models;
using SitecoreCognitiveServices.Foundation.NexSDK.Http.Models;
using SitecoreCognitiveServices.Foundation.NexSDK.View.Models;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.NexSDK
{
    public interface IViewService
    {
        /// <summary>
        /// Lists views that have been saved to the system
        /// </summary>
        /// <exception cref="NexosisClientException">Thrown when 4xx or 5xx response is received from server, or errors in parsing the response.</exception>
        /// <returns>A listing of views associated with your company</returns>
        Task<ViewDefinitionList> List(ViewQuery viewQuery = null);

        /// <summary>
        /// Gets a view
        /// </summary>
        /// <param name="query">The query critera for the data returned</param>
        /// <exception cref="NexosisClientException">Thrown when 4xx or 5xx response is received from server, or errors in parsing the response.</exception>
        /// <returns>A <see cref="ViewDetail"/> with data about the view definition and the view data itself.</returns>
        Task<ViewDetail> Get(ViewDataQuery query);


        /// <summary>
        /// Creates a view
        /// </summary>
        /// <param name="viewName">The name of the view</param>
        /// <param name="view">The <see cref="ViewInfo"/> with the specifics of the view</param>
        /// <returns>The definition of the created view</returns>
        Task<ViewDefinition> Create(string viewName, ViewInfo view);

        /// <summary>
        /// Deletes a view
        /// </summary>
        /// <param name="criteria">The criteria for the view delete as well as which data related to the view to delete</param>
        /// <returns></returns>
        Task Remove(ViewDeleteCriteria criteria);
    }
}