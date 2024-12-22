using Logic.Interfaces;
using Logic.Models;
using DAL.DataModels;

namespace DAL.DALServices
{
    public class CategoryDAL(DatabaseContext db) : ICategoryDAL
    {
        private DatabaseContext database { get; set; } = db;

        #region Category
        public List<Category> GetCategories()
        {
            List<Category> categories = new();
            List<CategoryDTO> categoryDTOs = database.Categories.ToList();

            foreach (CategoryDTO categoryDTO in categoryDTOs)
            {
                Category category = new()
                {
                    ID = categoryDTO.ID,
                    Name = categoryDTO.Name
                };
                
                categories.Add(category);
            }

            return categories;
        }

        public Category? GetCategory(int id)
        {
            if (!DoesCategoryIDExist(id))
            {
                return null;
            }
            
            CategoryDTO categoryDTO = database.Categories.FirstOrDefault(c => c.ID == id)!;

            Category category = new()
            {
                ID = categoryDTO.ID,
                Name = categoryDTO.Name
            };

            return category;
        }

        public void CreateCategory(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || DoesCategoryAlreadyExist(name)) return;
            
            database.Categories.Add(new CategoryDTO { Name = name });
            database.SaveChanges();
        }

        public void UpdateCategory(int id, string name)
        {
            if (id == 0 || !DoesCategoryIDExist(id))
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(name) || DoesCategoryAlreadyExist(name))
            {
                return;
            }
            
            CategoryDTO categoryDto = database.Categories.FirstOrDefault(c => c.ID == id)!;
            categoryDto.Name = name;
            database.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            if (id == 0 || !DoesCategoryIDExist(id)) return;
            
            database.Categories.Remove(database.Categories.FirstOrDefault(c => c.ID == id)!);
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
        public List<Subcategory> GetSubcategories(int categoryID)
        {
            List<Subcategory> subcategories = [];
            List<SubcategoryDTO> subcategoryDTOs = database.Subcategories.Where(sc => sc.Category.ID == categoryID).ToList();

            foreach (SubcategoryDTO subcategoryDTO in subcategoryDTOs)
            {
                Subcategory subcategory = new()
                {
                    ID = subcategoryDTO.ID,
                    Name = subcategoryDTO.Name
                };
                
                subcategories.Add(subcategory);
            }
            
            return subcategories;
        }

        public Subcategory? GetSubcategory(int subcategoryID)
        {
            if (!DoesSubcategoryIDExist(subcategoryID))
            {
                return null;
            }
            
            SubcategoryDTO subcategoryDTO = database.Subcategories.FirstOrDefault(sc => sc.ID == subcategoryID)!;

            Subcategory subcategory = new()
            {
                ID = subcategoryDTO.ID,
                Name = subcategoryDTO.Name
            };

            return subcategory;
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
            
            Category category = GetCategory(categoryID)!;
            CategoryDTO categoryDTO = new()
            {
                ID = category.ID,
                Name = category.Name
            };
            
            SubcategoryDTO newSubcategoryDto = new() { Name = name, Category = categoryDTO };
            database.Subcategories.Add(newSubcategoryDto);
            database.SaveChanges();
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

            SubcategoryDTO subcategoryDto = database.Subcategories.FirstOrDefault(sc => sc.ID == subcategoryID)!;
            subcategoryDto.Name = name;
            database.SaveChanges();
        }

        public void DeleteSubcategory(int id)
        {
            if (id == 0 || !DoesSubcategoryIDExist(id))
            {
                return;
            }
            
            database.Subcategories.Remove(database.Subcategories.FirstOrDefault(sc => sc.ID == id)!);
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
