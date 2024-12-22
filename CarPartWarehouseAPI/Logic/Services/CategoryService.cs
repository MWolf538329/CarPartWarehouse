using Logic.Interfaces;
using Logic.Models;

namespace Logic.Services
{
    public class CategoryService(ICategoryDAL categoryDal)
    {
        #region Category
        public List<Category> GetCategories()
        {
            return categoryDal.GetCategories();
        }

        public Category? GetCategory(int id)
        {
            return categoryDal.GetCategory(id);
        }

        public void CreateCategory(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || DoesCategoryAlreadyExist(name))
            {
                return;
            }
            
            categoryDal.CreateCategory(name);
        }

        public void UpdateCategory(int categoryID, string name)
        {
            if (categoryID == 0 || !DoesCategoryIDExist(categoryID))
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(name) || DoesCategoryAlreadyExist(name))
            {
                return;
            }
            
            categoryDal.UpdateCategory(categoryID, name);
        }

        public void DeleteCategory(int id)
        {
            if (id == 0 || !DoesCategoryIDExist(id))
            {
                return;
            }
            
            categoryDal.DeleteCategory(id);
        }

        public bool DoesCategoryAlreadyExist(string name)
        {
            return categoryDal.DoesCategoryAlreadyExist(name);
        }
        public bool DoesCategoryIDExist(int id)
        {
            return categoryDal.DoesCategoryIDExist(id);
        }
        #endregion

        #region Subcategory
        public List<Subcategory> GetSubcategories(int categoryId)
        {
            return categoryDal.GetSubcategories(categoryId);
        }

        public Subcategory? GetSubcategory(int subcategoryID)
        {
            return categoryDal.GetSubcategory(subcategoryID);
        }

        public void CreateSubcategory(int categoryID, string name)
        {
            if (categoryID == 0 || !DoesCategoryIDExist(categoryID))
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(name) || DoesSubcategoryAlreadyExist(name))
            {
                return;
            }
            
            categoryDal.CreateSubcategory(categoryID, name);
        }

        public void UpdateSubcategory(int subcategoryID, int categoryID, string name)
        {
            if (subcategoryID == 0 || !DoesSubcategoryIDExist(subcategoryID))
            {
                return;
            }

            if (categoryID == 0 || !DoesCategoryIDExist(categoryID))
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(name) || DoesSubcategoryAlreadyExist(name))
            {
                return;
            }

            categoryDal.UpdateSubcategory(subcategoryID, categoryID, name);
        }

        public void DeleteSubcategory(int id)
        {
            if (id == 0 || !DoesSubcategoryIDExist(id))
            {
                return;
            }
            
            categoryDal.DeleteSubcategory(id);
        }

        public bool DoesSubcategoryAlreadyExist(string name)
        {
            return categoryDal.DoesSubcategoryAlreadyExist(name);
        }
        public bool DoesSubcategoryIDExist(int id)
        {
            return categoryDal.DoesSubcategoryIDExist(id);
        }
        #endregion
        
        #region Product

        public List<Category> GetCategoriesWithSubcategoriesWithProducts()
        {
            return categoryDal.GetCategoriesWithSubcategoriesWithProducts();
        }
        #endregion
    }
}
