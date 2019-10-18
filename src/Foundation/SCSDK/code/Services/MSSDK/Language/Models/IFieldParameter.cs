using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language.Models
{
    public interface IFieldParameter : IConversationParameter
    {
        string ParamName { get; set; }
        bool IsOptional { get; set; }
        IParameterResult GetParameter(string paramValue, IConversationContext context);
        IntentInput GetInput(ItemContextParameters parameters, IConversation conversation);
    }
}