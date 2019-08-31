using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.MSSDK.Language.Models.Luis;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language.Models
{
    public interface IConversation
    {
        bool IsEnded { get; set; }
        bool IsConfirmed { get; set; }
        IIntent Intent { get; set; }
        LuisResult Result { get; set; }
        Dictionary<string, ParameterData> Data { get; set; }
    }
}