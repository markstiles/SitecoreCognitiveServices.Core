using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Polly;
using Polly.Fallback;
using Polly.Retry;
using Polly.Wrap;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Foundation.SCSDK.RetryPolicies
{
    public class MSSDKPolicyService : IMSSDKPolicyService
    {
        protected readonly ILogWrapper Logger;
        public MSSDKPolicyService(ILogWrapper logger)
        {
            Logger = logger;
        }
        
        public T ExecuteRetryAndCapture400Errors<T>(string requestType, int retryInSeconds, Func<T> action, T defaultValue)
        {
            var policyResult = Policy
                .Handle<WebException>(CheckError)
                .WaitAndRetry(
                    3,
                    retryAttempt => TimeSpan.FromSeconds(retryInSeconds),
                    (exception, span) =>
                    {
                        Logger.Info($"{requestType} failed: Too Many Requests. will retry", this);
                    })
                .ExecuteAndCapture(action);

            if (policyResult.Outcome == OutcomeType.Failure)
            {
                var exceptionMessage = policyResult?.FinalException?.Message ?? "";
                var innerExceptionMessage = policyResult?.FinalException?.InnerException?.Message ?? "";

                var additionalInfo = (exceptionMessage.Contains("(401) Unauthorized") || innerExceptionMessage.Contains("401"))
                    ? "; api key or url is incorrect"
                    : string.Empty;

                Logger.Error($"{requestType} failed{additionalInfo}", this, policyResult.FinalException);

                return defaultValue;
            }

            Logger.Info($"{requestType} Succeeded", this);

            return policyResult.Result;
        }

        public bool CheckError(WebException wex)
        {
            if (wex.Message.Contains("429"))
                return true;

            if (wex.InnerException != null && wex.InnerException.Message.Contains("429"))
                return true;

            return false;
        }
    }
}