using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SitecoreCognitiveServices.Foundation.NexSDK.DataSet.Enums;

namespace SitecoreCognitiveServices.Foundation.NexSDK.DataSet.Models
{
    public class ColumnMetadata
    {
        public ColumnType? DataType { get; set; }
        public ColumnRole? Role { get; set; }
        
        public ImputationStrategy? Imputation { get; set; }
        public AggregationStrategy? Aggregation { get; set; }
    }
}