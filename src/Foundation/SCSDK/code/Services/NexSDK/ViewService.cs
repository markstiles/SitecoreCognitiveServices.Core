using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sitecore.Reflection.Emit;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.NexSDK.Session;
using SitecoreCognitiveServices.Foundation.NexSDK.View;
using SitecoreCognitiveServices.Foundation.NexSDK.View.Models;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.NexSDK
{
    public class ViewService : IViewService
    {
        protected readonly IViewRepository ViewRepository;
        protected readonly ILogWrapper Logger;
        
        public ViewService(
            IViewRepository viewRepository,
            ILogWrapper logger)
        {
            ViewRepository = viewRepository;
            Logger = logger;
        }

        public async Task<ViewDefinitionList> List(ViewQuery viewQuery = null)
        {
            try
            {
                var result = await ViewRepository.List(viewQuery);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ViewService.List failed", this, ex);
            }

            return null;
        }

        public async Task<ViewDetail> Get(ViewDataQuery query)
        {
            try
            {
                var result = await ViewRepository.Get(query);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ViewService.Get failed", this, ex);
            }

            return null;
        }

        public async Task<ViewDefinition> Create(string viewName, ViewInfo view)
        {
            try
            {
                var result = await ViewRepository.Create(viewName, view);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("ViewService.Create failed", this, ex);
            }

            return null;
        }

        public async Task Remove(ViewDeleteCriteria criteria)
        {
            try
            {
                ViewRepository.Remove(criteria);
            }
            catch (Exception ex)
            {
                Logger.Error("ViewService.Remove failed", this, ex);
            }
        }
    }
}