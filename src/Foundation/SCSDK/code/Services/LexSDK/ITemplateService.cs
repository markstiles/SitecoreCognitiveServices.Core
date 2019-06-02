using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.LexSDK.Template.Models;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.LexSDK
{
    public interface ITemplateService
    {
        List<TemplateItem> GetTemplates(string configId = null);
    }
}