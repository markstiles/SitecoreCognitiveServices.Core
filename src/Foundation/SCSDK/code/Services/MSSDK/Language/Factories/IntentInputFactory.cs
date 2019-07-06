﻿using System;
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
        IntentInput Create(IntentInputType type, string inputLabel = "");
        IntentInput Create(IntentInputType type, List<ListItem> options, string inputLabel = "");
    }

    public class IntentInputFactory : IIntentInputFactory
    {
        public IntentInput Create(IntentInputType type, string inputLabel = "")
        {
            return new IntentInput()
            {
                Type = type,
                InputLabel = inputLabel,
                Options = new List<ListItem>()
            };
        }

        public IntentInput Create(IntentInputType type, List<ListItem> options, string inputLabel = "")
        {
            var os = Create(type, inputLabel);
            os.Options = options;

            return os;
        }
    }
}