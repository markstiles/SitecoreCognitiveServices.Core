using System;
using SitecoreCognitiveServices.Foundation.NexSDK.DataSet.Enums;

namespace SitecoreCognitiveServices.Foundation.NexSDK.DataSet.Models
{
    /// <summary>
    /// Search criteria for determining the data to remove from a dataset
    /// </summary>
    public class DataSetRemoveCriteria
    {

        public DataSetRemoveCriteria(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// The name of the dataset
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The start date (for Time Series DataSets) after which data should be removed
        /// </summary>
        public DateTimeOffset? StartDate { get; set; }

        /// <summary>
        /// The end date (for Time Series DataSets) before whcih data should be removed
        /// </summary>
        public DateTimeOffset? EndDate { get; set; }

        /// <summary>
        /// Options for deleting additional data related to the DataSet
        /// </summary>
        public DataSetDeleteOptions? Options { get; set; }
    }
}