using System;
using System.Collections.Generic;
using SitecoreCognitiveServices.Foundation.NexSDK.Http.Models;

namespace SitecoreCognitiveServices.Foundation.NexSDK.DataSet.Models
{
    /// <summary>
    /// Provides overview information for the DataSet including the column definitions.
    /// </summary>
    public class DataSetSummary : ReturnsQuotas
    {
        public Dictionary<string, ColumnMetadata> Columns { get; set; } = new Dictionary<string, ColumnMetadata>(StringComparer.OrdinalIgnoreCase);
        
        /// <summary>
        /// The name of the DataSet
        /// </summary>
        public string DataSetName { get; set; }
    }
}