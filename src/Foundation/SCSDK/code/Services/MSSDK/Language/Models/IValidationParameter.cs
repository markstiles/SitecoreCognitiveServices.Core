using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language.Models
{
    public interface IValidationParameter : IConversationParameter
    {
        bool IsValid(IConversationContext context);
        string GetErrorMessage();
    }
}