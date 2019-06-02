using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.LexSDK.Category.Models;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.LexSDK
{
    public interface ICategoryService
    {
        List<CategoryItem> ListCategories(string configId = null);
        List<CategoryItem> CreateCategories(List<CategoryItem> items, string configId = null);
        List<CategoryItem> UpdateCategories(List<CategoryItem> items, string configId = null);
        int DeleteCategories(List<CategoryItem> items, string configId = null);
    }
}