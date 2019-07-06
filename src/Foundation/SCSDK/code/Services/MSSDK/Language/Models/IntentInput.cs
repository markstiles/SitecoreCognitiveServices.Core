using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language.Enums;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language.Models
{
    public class IntentInput
    {
        public IntentInputType Type { get; set; }
        public string InputType => Enum.GetName(typeof(IntentInputType), Type);
        public List<ListItem> Options { get; set; }
        public string InputLabel { get; set; }
        
        public void AddOption(string key, string value)
        {
            Options.Add(new ListItem(key, value));
        }
    }
}