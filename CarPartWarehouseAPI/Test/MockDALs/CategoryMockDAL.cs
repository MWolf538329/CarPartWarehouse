using Logic.Interfaces;
using Logic.Models;

namespace Test.MockDALs
{
    internal class CategoryMockDAL : ICategoryDAL
    {
        public bool IsUsed;
        public bool IsCreated;
        public bool IsUpdated;
        public bool IsDeleted;
        
        public List<Category> Categories { get; } =
        [
            new() { ID = 1, Name = "Motor" },
            new() { ID = 2, Name = "Transmissie" }
        ];

        public List<Subcategory> Subcategories { get; } =
        [
            new() { ID = 1, Name = "Cilinders", Category = new Category { ID = 1, Name = "Motor" } },
            new() { ID = 2, Name = "Handgeschakelde Transmissie", Category = new Category { ID = 2, Name = "Transmissie" } },
            new() { ID = 3, Name = "Automatische Transmissie", Category = new Category { ID = 2, Name = "Transmissie" } }
        ];
        
        public List<Category> GetCategories()
        {
            IsUsed = true;

            return Categories;
        }

        public Category GetCategory(int id)
        {
            IsUsed = true;

            return Categories.FirstOrDefault(c => c.ID == id)!;
        }
        
        public void CreateCategory(string name)
        {
            IsUsed = true;

            Categories.Add(new Category { ID = 3, Name = name });

            if (Categories.Count == 3)
            {
                IsCreated = true;
            }
        }
        
        public void UpdateCategory(int id, string name)
        {
            IsUsed = true;

            Categories[id].Name = name;

            if (Categories[id].Name == name)
            {
                IsUpdated = true;
            }
        }
        
        public void DeleteCategory(int id)
        {
            IsUsed = true;
            
            Categories.RemoveAt(id);

            if (Categories.Count == 1)
            {
                IsDeleted = true;
            }
        }

        public bool DoesCategoryAlreadyExist(string name)
        {
            return Categories.Any(c => c.Name == name);
        }

        public bool DoesCategoryIDExist(int categoryID)
        {
            return Categories.Any(c => c.ID == categoryID);
        }

        public List<Subcategory> GetSubcategories(int categoryID)
        {
            IsUsed = true;

            return Subcategories.Where(sc => sc.Category.ID == categoryID).ToList();
        }

        public Subcategory? GetSubcategory(int subcategoryID)
        {
            IsUsed = true;

            return Subcategories.FirstOrDefault(sc => sc.ID == subcategoryID);
        }

        public void CreateSubcategory(int categoryID, string name)
        {
            IsUsed = true;
            
            Subcategories.Add(new Subcategory {ID = 4, Name = name, Category = new Category{ID = categoryID, Name = "Transmissie"}});

            if (Subcategories.Count == 4)
            {
                IsCreated = true;
            }
        }

        public void UpdateSubcategory(int subcategoryID, string name)
        {
            IsUsed = true;

            Subcategories[subcategoryID].Name = name;

            if (Subcategories[subcategoryID].Name == name)
            {
                IsUpdated = true;
            }
        }

        public void DeleteSubcategory(int subcategoryID)
        {
            IsUsed = true;
            
            Subcategories.RemoveAt(subcategoryID);

            if (Subcategories.Count == 2)
            {
                IsDeleted = true;
            }
        }

        public bool DoesSubcategoryAlreadyExist(string name)
        {
            return Subcategories.Any(sc => sc.Name == name);
        }

        public bool DoesSubcategoryIDExist(int subcategoryID)
        {
            return Subcategories.Any(sc => sc.ID == subcategoryID);
        }

        public List<Category> GetCategoriesWithSubcategoriesWithProducts()
        {
            throw new NotImplementedException();
        }
    }
}
