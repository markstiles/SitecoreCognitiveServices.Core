using System;
using System.Collections.Generic;
using SitecoreCognitiveServices.Foundation.NexSDK.DataSet.Models;
using SitecoreCognitiveServices.Foundation.NexSDK.Import.Enums;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Import.Models
{
    public abstract class ImportRequest
    {
        /// <summary>
        /// The name of the DataSet into which the data should be imported
        /// </summary>
        public string DataSetName { get; set; }

        /// <summary>
        /// Describes the columns that are in the data to be imported 
        /// </summary>
        public Dictionary<string, ColumnMetadata> Columns { get; set; } =
            new Dictionary<string, ColumnMetadata>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// The format of the data to be imported.  Optional.
        /// If not provided, Nexosis will attempt to examine the file and determine the type automatically
        /// </summary>
        public ImportContentType? ContentType { get; set; }
    }
}