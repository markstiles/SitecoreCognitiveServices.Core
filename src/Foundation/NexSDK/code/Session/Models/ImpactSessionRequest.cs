using System;
using SitecoreCognitiveServices.Foundation.NexSDK.Http.Enums;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Session.Models
{
    public class ImpactSessionRequest : TimeSeriesSessionRequest
    {
        /// <summary>
        /// The name of the event whose impact we are trying to determine
        /// </summary>
        public string EventName { get; set; }

        public ImpactSessionRequest(string dataSourceName, DateTimeOffset startDate,
            DateTimeOffset endDate, ResultInterval resultInterval, string eventName, string targetColumn = null)
        {
            DataSourceName = dataSourceName;
            if (targetColumn != null)
                TargetColumn = targetColumn;
            
            EventName = eventName;
            StartDate = startDate;
            EndDate = endDate;
            ResultInterval = resultInterval;
        }
    }
}