using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.LexSDK.Http;
using SitecoreCognitiveServices.Foundation.LexSDK.Http.Enums;
using SitecoreCognitiveServices.Foundation.LexSDK.Template.Models;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Template
{
    public interface ITemplateRepository
    {
        List<TemplateItem> GetTemplates(string configId = null);
    }
}