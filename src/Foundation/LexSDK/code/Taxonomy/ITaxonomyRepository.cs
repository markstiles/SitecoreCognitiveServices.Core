using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.LexSDK.Http;
using SitecoreCognitiveServices.Foundation.LexSDK.Http.Enums;
using SitecoreCognitiveServices.Foundation.LexSDK.Taxonomy.Models;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Taxonomy
{
    public interface ITaxonomyRepository
    {
        List<TaxonomyItem> GetTaxonomies(string configId = null);
        List<TaxonomyItem> CreateTaxonomies(List<TaxonomyItem> items, string configId = null);
        List<TaxonomyItem> UpdateTaxonomy(List<TaxonomyItem> items, string configId = null);
        int DeleteTaxonomy(List<string> itemIds, string configId = null);
    }
}