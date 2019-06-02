using System;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Model.Models
{
    public class ModelRemoveCriteria
    {
        /// <summary>
        /// The Id of the model to be removed
        /// </summary>
        public Guid? ModelId { get; set; }
        
        /// <summary>
        /// All models built from this DataSource should be removed
        /// </summary>
        public string DataSourceName { get; set; }

        /// <summary>
        /// Models created after this date should be removed
        /// </summary>
        public DateTimeOffset? CreatedAfterDate { get; set; }

        /// <summary>
        /// Models created before this date should be removed
        /// </summary>
        public DateTimeOffset? CreatedBeforeDate { get; set; }
    }
}