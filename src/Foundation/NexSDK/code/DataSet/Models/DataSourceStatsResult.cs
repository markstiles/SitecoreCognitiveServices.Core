﻿using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace SitecoreCognitiveServices.Foundation.NexSDK.DataSet.Models
{
    public class DataSourceStatsResult
    {
        /// <summary>
        /// Name of the dataset for which statistics were retrieved
        /// </summary>
        public string DataSetName { get; set; }
        /// <summary>
        /// Statistics about each column in the dataset
        /// </summary>
        public Dictionary<string, JObject> Columns { get; set; }
    }
}