using System;
using SitecoreCognitiveServices.Foundation.NexSDK.Http.Enums;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Session.Models
{
    public class ForecastSessionRequest : TimeSeriesSessionRequest
    {
        public ForecastSessionRequest(string dataSourceName, DateTimeOffset startDate, DateTimeOffset endDate, ResultInterval resultInterval, string targetColumn = null)
        {
            DataSourceName = dataSourceName;
            if (targetColumn != null)
                TargetColumn = targetColumn;
            
            StartDate = startDate;
            EndDate = endDate;
            ResultInterval = resultInterval;
        }
    }
}