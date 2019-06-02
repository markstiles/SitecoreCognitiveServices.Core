using System;
using System.Collections.Generic;
using SitecoreCognitiveServices.Foundation.NexSDK.DataSet.Models;

namespace SitecoreCognitiveServices.Foundation.NexSDK.View.Models
{
    public class ViewInfo
    {
        public string DataSetName { get; set; }

        public Dictionary<string, ColumnMetadata> Columns { get; set; } =
            new Dictionary<string, ColumnMetadata>(StringComparer.OrdinalIgnoreCase);

        public JoinMetadata[] Joins { get; set; }
    }
}