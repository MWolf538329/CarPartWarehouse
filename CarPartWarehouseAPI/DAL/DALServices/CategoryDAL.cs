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

        public void CreateCategory(string name)
        {
            if (string.IsNullOrEmpty(name) || DoesCategoryAlreadyExist(name)) return;


            database.Categories.Add(new() { Name = name });
            database.SaveChanges();
        }

        public void UpdateCategory(int id, string name)
        {
            if (id == 0 || !DoesCategoryIDExist(id)) return;

            if (string.IsNullOrEmpty(name) || DoesCategoryAlreadyExist(name)) return;

            
            Category category = database.Categories.Where(c => c.ID == id).FirstOrDefault()!;
            category.Name = name;
            database.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            if (id == 0 || !DoesCategoryIDExist(id)) return;

            
            database.Categories.Remove(database.Categories.Where(c => c.ID == id).FirstOrDefault()!);
            database.SaveChanges();
        }

        public bool DoesCategoryAlreadyExist(string name)
        {
            return database.Categories.Any(c => c.Name == name);
        }
        public bool DoesCategoryIDExist(int id)
        {
            return database.Categories.Any(c => c.ID == id);
        }
        #endregion

        #region Subcategory
        public List<Subcategory> GetSubcategories()
        {
            return database.Subcategories.ToList();
        }
        
        public List<Subcategory> GetSubcategories(int categoryID)
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

        public void CreateSubcategory(int categoryID, string name)
        {
            if (categoryID == 0 || !DoesCategoryIDExist(categoryID)) return;

            if (string.IsNullOrEmpty(name) || DoesSubcategoryAlreadyExist(name)) return;


            Category category = GetCategory(categoryID)!;
            Subcategory newSubcategory = new() { Name = name, Category = category };
            database.Subcategories.Add(newSubcategory);
            database.SaveChanges();
        }

        public void UpdateSubcategory(int subcategoryID, int categoryID, string name)
        {
            if (subcategoryID == 0 || !DoesSubcategoryIDExist(subcategoryID)) return;

            if (categoryID == 0 || !DoesCategoryIDExist(categoryID)) return;

            if (string.IsNullOrEmpty(name) || DoesSubcategoryAlreadyExist(name)) return;


            Subcategory subcategory = database.Subcategories.Where(sc => sc.ID == subcategoryID).FirstOrDefault()!;
            subcategory.Name = name;
            database.SaveChanges();
        }

        public void DeleteSubcategory(int id)
        {
            if (id == 0 || !DoesSubcategoryIDExist(id)) return;

            
            database.Subcategories.Remove(database.Subcategories.Where(sc => sc.ID == id).FirstOrDefault()!);
            database.SaveChanges();
        }

        public bool DoesSubcategoryAlreadyExist(string name)
        {
            return database.Subcategories.Any(sc => sc.Name == name);
        }
        public bool DoesSubcategoryIDExist(int id)
        {
            return database.Subcategories.Any(sc => sc.ID == id);
        }
        #endregion
    }
}
