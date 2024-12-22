using Logic.Interfaces;
using Logic.Models;

namespace Test.MockDALs
{
    internal class CategoryMockDAL : ICategoryDAL
    {
        public bool IsUsed;
        public bool IsAdded;
        public bool IsChanged;
        public List<Category> Categories { get; private set; }

        public CategoryMockDAL()
        {
            IsUsed = false;
            IsAdded = false;
            IsChanged = false;

            Categories = new()
            {
                new Category() { ID = 1, Name = "Motor" },
                new Category() { ID = 2, Name = "Transmissie" }
            };
        }

        #region Read
        public List<Category> GetCategories()
        {
            IsUsed = true;

            return Categories;
        }

        public Category GetCategory(int id)
        {
            IsUsed = true;

            return Categories.Where(c => c.ID == id).FirstOrDefault()!;

        }
        #endregion

        #region Create
        public void CreateCategory(string name)
        {
            IsUsed = true;

            Categories.Add(new Category() { ID = 3, Name = name });

            if (Categories.Count == 3)
            {
                IsAdded = true;
            }
        }
        #endregion

        #region Update
        public void EditCategory(int id, string name)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Delete
        public void DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        public bool DoesCategoryAlreadyExist(string name)
        {
            return Categories.Any(c => c.Name == name);
        }

        public void UpdateCategory(int categoryID, string name)
        {
            throw new NotImplementedException();
        }

        public bool DoesCategoryIDExist(int categoryID)
        {
            throw new NotImplementedException();
        }

        public List<Subcategory> GetSubcategories()
        {
            throw new NotImplementedException();
        }

        public List<Subcategory> GetSubcategories(int categoryID)
        {
            throw new NotImplementedException();
        }

        public Subcategory? GetSubcategory(int subcategoryID)
        {
            throw new NotImplementedException();
        }

        public void CreateSubcategory(int categoryID, string name)
        {
            throw new NotImplementedException();
        }

        public void UpdateSubcategory(int subcategoryID, string name)
        {
            throw new NotImplementedException();
        }

        public void DeleteSubcategory(int subcategory)
        {
            throw new NotImplementedException();
        }

        public bool DoesSubcategoryAlreadyExist(string name)
        {
            throw new NotImplementedException();
        }

        public bool DoesSubcategoryIDExist(int subcategoryID)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetCategoriesWithSubcategoriesWithProducts()
        {
            throw new NotImplementedException();
        }

        public void UpdateSubcategory(int subcategoryID, int categoryID, string name)
        {
            throw new NotImplementedException();
        }
    }
}
