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

        public void CreateCategory(string name)
        {
            if (string.IsNullOrEmpty(name) || DoesCategoryAlreadyExist(name)) return;


            _CategoryDAL.CreateCategory(name);
        }

        public void UpdateCategory(int categoryID, string name)
        {
            if (categoryID == 0 || !DoesCategoryIDExist(categoryID)) return;
            if (string.IsNullOrEmpty(name) || DoesCategoryAlreadyExist(name)) return;

            
            _CategoryDAL.UpdateCategory(categoryID, name);
        }

        public void DeleteCategory(int id)
        {
            if (id == 0 || !DoesCategoryIDExist(id)) return;

            
            _CategoryDAL.DeleteCategory(id);
        }

        public bool DoesCategoryAlreadyExist(string name)
        {
            return _CategoryDAL.DoesCategoryAlreadyExist(name);
        }
        public bool DoesCategoryIDExist(int id)
        {
            return _CategoryDAL.DoesCategoryIDExist(id);
        }
        #endregion

        #region Subcategory
        public List<Subcategory> GetSubcategories()
        {
            return _CategoryDAL.GetSubcategories();
        }

        public List<Subcategory> GetSubcategoriesFromCategory(int categoryID)
        {
            return _CategoryDAL.GetSubcategories(categoryID);
        }

        public Subcategory? GetSubcategory(int subcategoryID)
        {
            return _CategoryDAL.GetSubcategory(subcategoryID);
        }

        public void CreateSubcategory(int categoryID, string name)
        {
            if (categoryID == 0 || !DoesCategoryIDExist(categoryID)) return;
            if (string.IsNullOrEmpty(name) || DoesSubcategoryAlreadyExist(name)) return;


            _CategoryDAL.CreateSubcategory(categoryID, name);
        }

        public void UpdateSubcategory(int subcategoryID, int categoryID, string name)
        {
            if (subcategoryID == 0 || !DoesSubcategoryIDExist(subcategoryID)) return;
            if (categoryID == 0 || !DoesCategoryIDExist(categoryID)) return;
            if (string.IsNullOrEmpty(name) || DoesSubcategoryAlreadyExist(name)) return;


            _CategoryDAL.UpdateSubcategory(subcategoryID, categoryID, name);
        }

        public void DeleteSubcategory(int id)
        {
            if (id == 0 || !DoesSubcategoryIDExist(id)) return;

            
            _CategoryDAL.DeleteSubcategory(id);
        }

        public bool DoesSubcategoryAlreadyExist(string name)
        {
            return _CategoryDAL.DoesSubcategoryAlreadyExist(name);
        }
        public bool DoesSubcategoryIDExist(int id)
        {
            return _CategoryDAL.DoesSubcategoryIDExist(id);
        }
        #endregion
    }
}
