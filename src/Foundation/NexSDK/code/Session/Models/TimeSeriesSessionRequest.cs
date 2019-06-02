using System;
using SitecoreCognitiveServices.Foundation.NexSDK.Http.Enums;

namespace SitecoreCognitiveServices.Foundation.NexSDK.Session.Models
{
    public abstract class TimeSeriesSessionRequest : SessionRequest
    {
        /// <summary>
        /// The Start Date of the session
        /// </summary>
        public DateTimeOffset StartDate { get; set; }

        /// <summary>
        /// The End Date of the session
        /// </summary>
        public DateTimeOffset EndDate { get; set; }

        /// <summary>
        /// The <see cref="ResultInterval" /> that Nexosis should use for forecasting  
        /// </summary>
        public ResultInterval? ResultInterval { get; set; }

    }
}