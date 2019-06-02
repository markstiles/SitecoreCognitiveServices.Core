using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.NexSDK.Http.Models;
using SitecoreCognitiveServices.Foundation.NexSDK.Import.Models;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Import
{
    public interface IImportRepository
    {
        /// <summary>
        /// List imports that have been run. This will show information about them such as id and status
        /// </summary>
        /// <param name="query">The query criteria for the Imports to be returned</param>
        /// <returns>The list of <see cref="ImportDetail"/> objects.</returns>
        /// <exception cref="NexosisClientException">Thrown when 4xx or 5xx response is received from server, or errors in parsing the response.</exception>
        /// <remarks>GET of https://ml.nexosis.com/api/imports</remarks>
        Task<ImportDetailList> List(ImportDetailQuery query = null);


        /// <summary>
        /// Retrieve an import that has been requested.  This will show information such as id and status
        /// </summary>
        /// <param name="id">The identifier of the import</param>
        /// <returns>A <see cref="ImportDetail" /> populated with the import information</returns>
        /// <exception cref="NexosisClientException">Thrown when 4xx or 5xx response is received from server, or errors in parsing the response.</exception>
        /// <remarks>GET of https://ml.nexosis.com/api/imports/{id}</remarks>
        Task<ImportDetail> Get(Guid id);


        /// <summary>
        /// Import data into the Nexosis Api from a file on AWS S3
        /// </summary>
        /// <param name="detail">The details required to import from a file on S3</param>
        /// <remarks>POST of https://ml.nexosis.com/api/imports/S3</remarks>
        /// <exception cref="NexosisClientException">Thrown when 4xx or 5xx response is received from server, or errors in parsing the response.</exception>
        /// <returns>A <see cref="ImportDetail" /> populated with the import information</returns>
        Task<ImportDetail> ImportFromS3(ImportFromS3Request detail);

        /// <summary>
        /// Import data into the Nexosis Api by issuing an HTTP GET to a url
        /// </summary>
        /// <param name="detail">The details required to import from a url</param>
        /// <remarks>POST of https://ml.nexosis.com/api/imports/url</remarks>
        /// <exception cref="NexosisClientException">Thrown when 4xx or 5xx response is received from server, or errors in parsing the response.</exception>
        /// <returns>A <see cref="ImportDetail" /> populated with the import information</returns>
        Task<ImportDetail> ImportFromUrl(ImportFromUrlRequest detail);

        /// <summary>
        /// Import data into the Nexosis Api from a file in Azure Blob storage
        /// </summary>
        /// <param name="detail">The details required to import from Azure Blob storage</param>
        /// <remarks>POST of https://ml.nexosis.com/api/imports/azure</remarks>
        /// <exception cref="NexosisClientException">Thrown when 4xx or 5xx response is received from server, or errors in parsing the response.</exception>
        /// <returns>A <see cref="ImportDetail" /> populated with the import information</returns>
        Task<ImportDetail> ImportFromAzure(ImportFromAzureRequest detail);
    }
}