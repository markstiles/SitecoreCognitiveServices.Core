using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.LexSDK.Taxonomy.Models;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.LexSDK
{
    public interface ITaxonomyService
    {
        List<TaxonomyItem> GetTaxonomies(string configId = null);
        List<TaxonomyItem> CreateTaxonomies(List<TaxonomyItem> items, string configId = null);
        List<TaxonomyItem> UpdateTaxonomy(List<TaxonomyItem> items, string configId = null);
        int DeleteTaxonomy(List<string> itemIds, string configId = null);
    }
}