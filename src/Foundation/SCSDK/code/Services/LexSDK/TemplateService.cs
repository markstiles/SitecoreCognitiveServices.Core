using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.LexSDK.Template;
using SitecoreCognitiveServices.Foundation.LexSDK.Template.Models;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.LexSDK
{
    public class TemplateService : ITemplateService
    {
        protected ITemplateRepository TemplateRepository;
        protected ILogWrapper Logger;

        public TemplateService(
            ITemplateRepository templateRepository,
            ILogWrapper logger)
        {
            TemplateRepository = templateRepository;
            Logger = logger;
        }
        
        public virtual List<TemplateItem> GetTemplates(string configId = null)
        {
            try
            {
                var result = TemplateRepository.GetTemplates(configId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("TemplateRepository.GetTemplates failed", this, ex);
            }

            return null;
        }
    }
}