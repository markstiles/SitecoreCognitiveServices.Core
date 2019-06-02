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
        IParameterResult GetSuccess(object returnValue);
        IParameterResult GetFailure();
        IParameterResult GetFailure(string errorMessage);
    }

    public class ParameterResultFactory : IParameterResultFactory
    {
        public IParameterResult GetSuccess(object returnValue)
        {
            return new ParameterResult
            {
                HasFailed = false,
                Error = "",
                ReturnValue = returnValue
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
                ReturnValue = null
            };
        }
    }
}