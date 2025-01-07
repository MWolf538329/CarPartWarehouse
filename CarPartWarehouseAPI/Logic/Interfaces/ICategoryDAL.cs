using Logic.Models;

namespace Logic.Interfaces;

public interface ICategoryDAL
{
    // Category
    public List<Category> GetCategories();
    public Category? GetCategory(int categoryID);
    public void CreateCategory(string name);
    public void UpdateCategory(int categoryID, string name);
    public void DeleteCategory(int id);

    public bool DoesCategoryAlreadyExist(string name);
    public bool DoesCategoryIDExist(int id);

    // Subcategory
    public List<Subcategory> GetSubcategories(int categoryID);
    public Subcategory? GetSubcategory(int subcategoryID);
    public void CreateSubcategory(int categoryID, string name);
    public void UpdateSubcategory(int subcategoryID, string name);
    public void DeleteSubcategory(int id);

    public bool DoesSubcategoryAlreadyExist(string name);
    public bool DoesSubcategoryIDExist(int id);
        
    // Product
    public List<Category> GetCategoriesWithSubcategoriesWithProducts();
}