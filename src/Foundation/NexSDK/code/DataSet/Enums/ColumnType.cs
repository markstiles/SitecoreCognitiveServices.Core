using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SitecoreCognitiveServices.Foundation.NexSDK.DataSet.Enums
{
    public enum ColumnType
    {
        // Order of values is relevant for priority of recommended type
        String = 0,
        Numeric = 1,
        Logical = 2,
        Date = 3,
        NumericMeasure = -1,
        Text = 4
    }
}