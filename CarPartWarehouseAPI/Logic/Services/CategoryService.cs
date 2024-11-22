using Logic.Interfaces;
using Logic.Models;

namespace Logic.Services
{
    public class CategoryService
    {
        readonly ICategoryDAL _CategoryDAL;

        public CategoryService(ICategoryDAL categoryDAL) 
        {
            _CategoryDAL = categoryDAL;
        }

        #region Category
        public List<Category> GetCategories()
        {
            return _CategoryDAL.GetCategories();
        }

        public Category? GetCategory(int id)
        {
            return _CategoryDAL.GetCategory(id);
        }

        public List<Category> GetCategoriesWithSubcategoriesWithProducts()
        {
            return _CategoryDAL.GetCategoriesWithSubcategoriesWithProducts();
        }

        public void AddCategory(string name)
        {
            if (!_CategoryDAL.DoesCategoryAlreadyExist(name))
            {
                _CategoryDAL.AddCategory(name);
            }
        }

        public void UpdateCategory(int categoryID, string name)
        {
            if (categoryID != 0 && !string.IsNullOrEmpty(name))
            {
                _CategoryDAL.UpdateCategory(categoryID, name);
            }
        }

        public void DeleteCategory(int categoryID)
        {
            if (categoryID != 0)
            {
                _CategoryDAL.DeleteCategory(categoryID);
            }
        }

        public bool DoesCategoryAlreadyExist(string name)
        {
            return _CategoryDAL.DoesCategoryAlreadyExist(name);
        }
        public bool DoesCategoryIDExist(int categoryID)
        {
            return _CategoryDAL.DoesCategoryIDExist(categoryID);
        }
        #endregion

        #region Subcategory
        public List<Subcategory> GetSubcategories()
        {
            return _CategoryDAL.GetSubcategories();
        }

        public List<Subcategory> GetSubcategoriesFromCategory(int categoryID)
        {
            return _CategoryDAL.GetSubcategoriesFromCategory(categoryID);
        }

        public Subcategory? GetSubcategory(int subcategoryID)
        {
            return _CategoryDAL.GetSubcategory(subcategoryID);
        }

        public void AddSubcategory(int categoryID, string name)
        {
            if (!_CategoryDAL.DoesSubcategoryAlreadyExist(name))
            {
                _CategoryDAL.AddSubcategory(categoryID, name);
            }
        }

        public void UpdateSubcategory(int subcategoryID, string name)
        {
            if (subcategoryID != 0 && !string.IsNullOrEmpty(name))
            {
                _CategoryDAL.UpdateSubcategory(subcategoryID, name);
            }
        }

        public void DeleteSubcategory(int subcategoryID)
        {
            if (subcategoryID != 0)
            {
                _CategoryDAL.DeleteSubcategory(subcategoryID);
            }
        }

        public bool DoesSubcategoryAlreadyExist(string name)
        {
            return _CategoryDAL.DoesSubcategoryAlreadyExist(name);
        }
        public bool DoesSubcategoryIDExist(int subcategoryID)
        {
            return _CategoryDAL.DoesSubcategoryIDExist(subcategoryID);
        }
        #endregion
    }
}
