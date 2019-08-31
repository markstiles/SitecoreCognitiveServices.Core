using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Extensions.DependencyInjection;
using SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language.Models;
using SitecoreCognitiveServices.Foundation.MSSDK.Language.Models.Luis;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language.Factories
{
    public interface IParameterResultFactory
    {
        IParameterResult GetSuccess(string displayName, object dataValue);
        IParameterResult GetFailure();
        IParameterResult GetFailure(string errorMessage);
    }

    public class ParameterResultFactory : IParameterResultFactory
    {
        public IParameterResult GetSuccess(string displayName, object dataValue)
        {
            return new ParameterResult
            {
                HasFailed = false,
                Error = "",
                DisplayName = displayName,
                DataValue = dataValue
            };
        }

        public IParameterResult GetFailure()
        {
            return GetFailure("");
        }

        public IParameterResult GetFailure(string errorMessage)
        {
            return new ParameterResult
            {
                HasFailed = true,
                Error = errorMessage,
                DisplayName = "",
                DataValue = null
            };
        }
    }
}