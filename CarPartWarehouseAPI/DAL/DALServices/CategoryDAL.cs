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

        public List<Category> GetCategories()
        {
            return categorySet.ToList();
        }

        public Category GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public bool DoesCategoryAlreadyExist(string name)
        {
            return categorySet.Any(c => c.Name == name);
        }

        public void AddCategory(string name)
        {
            Category newCategory = new() { Name = name };

            categorySet.Add(newCategory);
            database.SaveChanges();
        }
    }
}
