using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.LexSDK.Category.Models;
using SitecoreCognitiveServices.Foundation.LexSDK.Http;
using SitecoreCognitiveServices.Foundation.LexSDK.Http.Enums;

namespace SitecoreCognitiveServices.Foundation.LexSDK.Category
{
    public interface ICategoryRepository
    {
        List<CategoryItem> ListCategories(string configId = null);
        List<CategoryItem> CreateCategories(List<CategoryItem> items, string configId = null);
        List<CategoryItem> UpdateCategories(List<CategoryItem> items, string configId = null);
        int DeleteCategories(List<CategoryItem> items, string configId = null);
    }
}