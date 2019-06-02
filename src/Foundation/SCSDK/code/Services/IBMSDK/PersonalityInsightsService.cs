using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.IBMSDK.PersonalityInsights;
using SitecoreCognitiveServices.Foundation.IBMSDK.PersonalityInsights.Models;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.IBMSDK
{
    public class PersonalityInsightsService : IPersonalityInsightsService
    {
        protected IPersonalityInsightsRepository PersonalityInsightsRepository;
        protected ILogWrapper Logger;

        public PersonalityInsightsService(
            IPersonalityInsightsRepository personalityInsightsRepository,
            ILogWrapper logger)
        {
            PersonalityInsightsRepository = personalityInsightsRepository;
            Logger = logger;
        }
        
        public Profile Profile(Content content, string contentType, string contentLanguage = null, string acceptLanguage = null, bool? rawScores = null, bool? csvHeaders = null, bool? consumptionPreferences = null)
        {
            try
            {
                var result = PersonalityInsightsRepository.Profile(content, contentType, contentLanguage, acceptLanguage, rawScores, csvHeaders, consumptionPreferences);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("PersonalityInsightsService.Profile failed", this, ex);
            }

            return null;
        }
    }
}