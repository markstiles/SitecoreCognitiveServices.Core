﻿using System;
using System.Collections.Generic;
using SitecoreCognitiveServices.Foundation.NexSDK.DataSet.Models;

namespace SitecoreCognitiveServices.Foundation.NexSDK.View.Models
{
    public class JoinMetadata
    {
        // Only one join source should be set on any join
        public DataSetJoinSource DataSet { get; set; }

        //Optionally set a calendar join source. exclusive of dataset
        public CalendarJoinSource Calendar { get; set; }

        public Dictionary<string, JoinColumnMetadata> ColumnOptions { get; set; } =
            new Dictionary<string, JoinColumnMetadata>(StringComparer.OrdinalIgnoreCase);
    }
}