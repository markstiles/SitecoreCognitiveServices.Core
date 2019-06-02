using System;
using SitecoreCognitiveServices.Foundation.NexSDK.DataSet.Enums;
using SitecoreCognitiveServices.Foundation.NexSDK.DataSet.Models;
using SitecoreCognitiveServices.Foundation.NexSDK.Http.Models;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Vocabulary.Models
{
    public class VocabularySummary : Resource
    {
        /// <summary>
        /// The Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The data source from which this vocabulary was built
        /// </summary>
        public string DataSourceName { get; set; }

        /// <summary>
        /// The column name in the data source from which this vocabulary was bui;t
        /// </summary>
        public string ColumnName { get; set; }
        
        /// <summary>
        /// The type of data source (data set or view) that was used
        /// </summary>
        public DataSourceType DataSourceType { get; set; }

        /// <summary>
        /// The date / time that the vocabulary was created
        /// </summary>
        public DateTimeOffset? CreatedOnDate { get; set; }


        /// <summary>
        /// The Session that created the vocabulary
        /// </summary>
        public Guid CreatedBySessionId { get; set; }
    }
}