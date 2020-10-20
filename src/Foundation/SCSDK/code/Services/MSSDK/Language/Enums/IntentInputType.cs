using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.MSSDK.Language.Enums
{
    public enum IntentInputType {
        [Display(Name = "Radio")] Radio,
        [Display(Name = "LinkList")] LinkList,
        [Display(Name = "Checkbox")] Checkbox,
        [Display(Name = "Text")] Text,
        [Display(Name = "Password")] Password,
        [Display(Name = "ItemSearch")] ItemSearch,
        [Display(Name = "ListSearch")] ListSearch,
        [Display(Name = "ExternalLinks")] ExternalLinks,
        [Display(Name = "None")] None
    }
}