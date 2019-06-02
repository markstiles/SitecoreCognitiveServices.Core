using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language.Enums;
using SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language.Models;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language.Factories
{
    public interface IIntentInputFactory
    {
        IntentInput Create(IntentInputType type);
        IntentInput Create(IntentInputType type, List<ListItem> options);
    }

    public class IntentInputFactory : IIntentInputFactory
    {
        public IntentInput Create(IntentInputType type)
        {
            return new IntentInput()
            {
                Type = type,
                Options = new List<ListItem>()
            };
        }

        public IntentInput Create(IntentInputType type, List<ListItem> options)
        {
            var os = Create(type);
            os.Options = options;

            return os;
        }
    }
}