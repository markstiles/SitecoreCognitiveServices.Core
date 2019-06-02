using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SitecoreCognitiveServices.Foundation.NexSDK.DataSet.Enums
{
    public enum ImputationStrategy
    {
        Zeroes,
        Mean,
        Median,
        Mode
    }
}