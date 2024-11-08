using Logic.Interfaces;
using Logic.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.DALServices
{
    public class CategoryDAL : ICategoryDAL
    {
        private DbSet<Category> categorySet { get; set; }
        private DatabaseContext database { get; set; }

        public CategoryDAL(DatabaseContext db)
        {
            database = db;
            categorySet = database.Categories;
        }

        #region Read
        public List<Category> GetCategories()
        {
            return categorySet.ToList();
        }

        public Category GetCategory(int id)
        {
            if (DoesEntryExist(id))
            {
                return categorySet.Where(c => c.ID == id).FirstOrDefault()!;
            }

            return new Category();
        }
        #endregion

        #region Create
        public void AddCategory(string name)
        {
            Category newCategory = new() { Name = name };

            categorySet.Add(newCategory);
            database.SaveChanges();
        }
        #endregion

        #region Update
        public void EditCategory(int id, string name)
        {
            if (DoesEntryExist(id))
            {
                Category category = categorySet.Where(c => c.ID == id).FirstOrDefault()!;
                category.Name = name;
                database.SaveChanges();
            }
        }
        #endregion

        #region Delete
        public void DeleteCategory(int id)
        {
            if (DoesEntryExist(id))
            {
                categorySet.Remove(categorySet.Where(c => c.ID == id).FirstOrDefault()!);
            }
        }
        #endregion

        public bool DoesCategoryAlreadyExist(string name)
        {
            return categorySet.Any(c => c.Name == name);
        }

        private bool DoesEntryExist(int id)
        {
            return categorySet.Any(c => c.ID == id);
        }
    }
}
