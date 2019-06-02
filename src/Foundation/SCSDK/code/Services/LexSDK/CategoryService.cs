using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.LexSDK.Category;
using SitecoreCognitiveServices.Foundation.LexSDK.Category.Models;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.LexSDK
{
    public class CategoryService : ICategoryService
    {
        protected ICategoryRepository CategoryRepository;
        protected ILogWrapper Logger;

        public CategoryService(
            ICategoryRepository categoryRepository,
            ILogWrapper logger)
        {
            CategoryRepository = categoryRepository;
            Logger = logger;
        }
        
        public virtual List<CategoryItem> ListCategories(string configId = null)
        {
            try
            {
                var result = CategoryRepository.ListCategories(configId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("CategoryRepository.ListCategories failed", this, ex);
            }

            return null;
        }

        public virtual List<CategoryItem> CreateCategories(List<CategoryItem> items, string configId = null)
        {
            try
            {
                var result = CategoryRepository.CreateCategories(items, configId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("CategoryRepository.CreateCategories failed", this, ex);
            }

            return null;
        }

        public virtual List<CategoryItem> UpdateCategories(List<CategoryItem> items, string configId = null)
        {
            try
            {
                var result = CategoryRepository.UpdateCategories(items, configId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("CategoryRepository.UpdateCategories failed", this, ex);
            }

            return null;
        }

        public virtual int DeleteCategories(List<CategoryItem> items, string configId = null)
        {
            try
            {
                var result = CategoryRepository.DeleteCategories(items, configId);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("CategoryRepository.DeleteCategories failed", this, ex);
            }

            return -1;
        }
    }
}