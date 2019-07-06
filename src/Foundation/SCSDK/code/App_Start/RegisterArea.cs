using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Sitecore.Pipelines;

namespace SitecoreCognitiveServices.Foundation.SCSDK
{
    public class CognitiveAreaRegistration : AreaRegistration
    {
        public override string AreaName => "SitecoreCognitiveServices";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(AreaName, "SitecoreCognitiveServices/{controller}/{action}", new
            {
                area = AreaName
            });
        }
    }
}