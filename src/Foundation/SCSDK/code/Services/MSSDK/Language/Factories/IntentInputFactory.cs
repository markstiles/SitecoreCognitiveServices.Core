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
        IntentInput Create(IntentInputType type, string inputLabel = "", Dictionary<string, string> parameters = null);
        IntentInput Create(IntentInputType type, List<ListItem> options, string inputLabel = "", Dictionary<string, string> parameters = null);
    }

    public class IntentInputFactory : IIntentInputFactory
    {
        public IntentInput Create(IntentInputType type, string inputLabel = "", Dictionary<string, string> parameters = null)
        {
            return new IntentInput()
            {
                Type = type,
                InputLabel = inputLabel,
                Parameters = parameters ?? new Dictionary<string, string>(),
                Options = new List<ListItem>()
            };
        }

        public IntentInput Create(IntentInputType type, List<ListItem> options, string inputLabel = "", Dictionary<string, string> parameters = null)
        {
            var os = Create(type, inputLabel, parameters);
            os.Options = options;

            return os;
        }
    }
}