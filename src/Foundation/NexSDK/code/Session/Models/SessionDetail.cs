using System;
using System.Collections.Generic;
using SitecoreCognitiveServices.Foundation.NexSDK.DataSet.Models;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Session.Models
{
    public class SessionDetail
    {
        /// <summary>Name of the dataset on which the session will operate</summary>
        public string DataSetName { get; set; }

        /// <summary>Metadata about each column in the dataset, for purposes of the session</summary>
        /// <remarks>This is initialized as a case-insensitive dictionary. The API ignores case for column names.</remarks>
        public Dictionary<string, ColumnMetadata> Columns { get; set; } = new Dictionary<string, ColumnMetadata>(StringComparer.OrdinalIgnoreCase);
    }
}
