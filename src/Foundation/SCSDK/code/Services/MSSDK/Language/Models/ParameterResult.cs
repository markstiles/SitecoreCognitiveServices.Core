using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language.Models
{
    public interface IParameterResult
    {
        bool HasFailed { get; set; }
        string Error { get; set; }
        string DisplayName { get; set; }
        object DataValue { get; set; }
    }

    public class ParameterResult : IParameterResult
    {
        public bool HasFailed { get; set; }
        public string Error { get; set; }
        public string DisplayName { get; set; }
        public object DataValue { get; set; }
    }
}