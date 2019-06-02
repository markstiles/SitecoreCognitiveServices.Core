using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SitecoreCognitiveServices.Foundation.NexSDK.DataSet.Enums
{
    public enum AggregationStrategy
    {
        Sum,
        Mean,
        Median,
        Mode,
        Min,
        Max,
    }
}