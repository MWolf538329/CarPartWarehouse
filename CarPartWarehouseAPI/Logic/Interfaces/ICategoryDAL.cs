using Logic.Models;

namespace Logic.Interfaces
{
    public interface ICategoryDAL
    {
        // Category
        public List<Category> GetCategories();
        public Category? GetCategory(int categoryID);
        public List<Category> GetCategoriesWithSubcategoriesWithProducts();
        public void AddCategory(string name);
        public void UpdateCategory(int categoryID, string name);
        public void DeleteCategory(int categoryID);

        public bool DoesCategoryAlreadyExist(string name);
        public bool DoesCategoryIDExist(int categoryID);

        // Subcategory
        public List<Subcategory> GetSubcategories();
        public List<Subcategory> GetSubcategoriesFromCategory(int categoryID);
        public Subcategory? GetSubcategory(int subcategoryID);
        public void AddSubcategory(int categoryID, string name);
        public void UpdateSubcategory(int subcategoryID, string name);
        public void DeleteSubcategory(int subcategory);

        public bool DoesSubcategoryAlreadyExist(string name);
        public bool DoesSubcategoryIDExist(int subcategoryID);
    }
}
