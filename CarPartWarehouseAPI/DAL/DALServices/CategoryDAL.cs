using Logic.Interfaces;
using Logic.Models;

namespace DAL.DALServices
{
    public class CategoryDAL : ICategoryDAL
    {
        private DatabaseContext database { get; set; }

        public CategoryDAL(DatabaseContext db)
        {
            database = db;
        }

        #region Category
        public List<Category> GetCategories()
        {
            return database.Categories.ToList();
        }

        public Category? GetCategory(int id)
        {
            if (DoesCategoryIDExist(id))
            {
                return database.Categories.Where(c => c.ID == id).FirstOrDefault()!;
            }

            return null;
        }

        public List<Category> GetCategoriesWithSubcategoriesWithProducts()
        {
            return database.Categories.ToList();
        }

        public void AddCategory(string name)
        {
            Category newCategory = new() { Name = name };

            database.Categories.Add(newCategory);
            database.SaveChanges();
        }

        public void UpdateCategory(int id, string name)
        {
            if (DoesCategoryIDExist(id))
            {
                Category category = database.Categories.Where(c => c.ID == id).FirstOrDefault()!;
                category.Name = name;
                database.SaveChanges();
            }
        }

        public void DeleteCategory(int id)
        {
            if (DoesCategoryIDExist(id))
            {
                database.Categories.Remove(database.Categories.Where(c => c.ID == id).FirstOrDefault()!);
            }
        }

        public bool DoesCategoryAlreadyExist(string name)
        {
            return database.Categories.Any(c => c.Name == name);
        }

        public bool DoesCategoryIDExist(int categoryID)
        {
            return database.Categories.Any(c => c.ID == categoryID);
        }
        #endregion

        #region Subcategory
        public List<Subcategory> GetSubcategories()
        {
            return database.Subcategories.ToList();
        }
        
        public List<Subcategory> GetSubcategoriesFromCategory(int categoryID)
        {
            return database.Subcategories.Where(sc => sc.Category.ID == categoryID).ToList();
        }

        public Subcategory? GetSubcategory(int subcategoryID)
        {
            if (DoesSubcategoryIDExist(subcategoryID))
            {
                return database.Subcategories.Where(sc => sc.ID == subcategoryID).FirstOrDefault()!;
            }

            return null;
        }

        public void AddSubcategory(int categoryID, string name)
        {
            if (DoesCategoryIDExist(categoryID))
            {
                Category category = GetCategory(categoryID)!;

                Subcategory newSubcategory = new() { Name = name, Category = category };

                database.Subcategories.Add(newSubcategory);
                database.SaveChanges();
            }
        }

        public void UpdateSubcategory(int subcategoryID, string name)
        {
            if (DoesSubcategoryIDExist(subcategoryID))
            {
                Subcategory subcategory = database.Subcategories.Where(sc => sc.ID == subcategoryID).FirstOrDefault()!;
                subcategory.Name = name;
                database.SaveChanges();
            }
        }

        public void DeleteSubcategory(int subcategoryID)
        {
            if (DoesSubcategoryIDExist(subcategoryID))
            {
                database.Subcategories.Remove(database.Subcategories.Where(sc => sc.ID == subcategoryID).FirstOrDefault()!);
            }
        }

        public bool DoesSubcategoryAlreadyExist(string name)
        {
            return database.Subcategories.Any(c => c.Name == name);
        }

        public bool DoesSubcategoryIDExist(int subcategoryID)
        {
            return database.Subcategories.Any(sc => sc.ID == subcategoryID);
        }
        #endregion
    }
}
