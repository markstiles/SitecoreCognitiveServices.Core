using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.LexSDK.Document;
using SitecoreCognitiveServices.Foundation.LexSDK.Document.Models;
using SitecoreCognitiveServices.Foundation.LexSDK.Taxonomy;
using SitecoreCognitiveServices.Foundation.LexSDK.Taxonomy.Models;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.LexSDK
{
    public class TaxonomyService : ITaxonomyService
    {
        protected ITaxonomyRepository TaxonomyRepository;
        protected ILogWrapper Logger;

        public TaxonomyService(
            ITaxonomyRepository taxonomyRepository,
            ILogWrapper logger)
        {
            TaxonomyRepository = taxonomyRepository;
            Logger = logger;
        }

        public virtual List<TaxonomyItem> GetTaxonomies(string configId = null)
        {
            try
            {
                var result = TaxonomyRepository.GetTaxonomies(configId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("TaxonomyRepository.GetTaxonomies failed", this, ex);
            }

            return null;
        }

        public virtual List<TaxonomyItem> CreateTaxonomies(List<TaxonomyItem> items, string configId = null)
        {
            try
            {
                var result = TaxonomyRepository.CreateTaxonomies(items, configId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("TaxonomyRepository.CreateTaxonomies failed", this, ex);
            }

            return null;
        }

        public virtual List<TaxonomyItem> UpdateTaxonomy(List<TaxonomyItem> items, string configId = null)
        {
            try
            {
                var result = TaxonomyRepository.UpdateTaxonomy(items, configId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("TaxonomyRepository.UpdateTaxonomy failed", this, ex);
            }

            return null;
        }

        public virtual int DeleteTaxonomy(List<string> itemIds, string configId = null)
        {
            try
            {
                var result = TaxonomyRepository.DeleteTaxonomy(itemIds, configId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("TaxonomyRepository.DeleteTaxonomy failed", this, ex);
            }

            return -1;
        }
    }
}