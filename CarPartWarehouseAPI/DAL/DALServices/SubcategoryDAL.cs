using Logic.Interfaces;
using Logic.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.DALServices
{
    public class SubcategoryDAL : ISubcategoryDAL
    {
        private DbSet<Subcategory> subcategorySet { get; set; }
        private DatabaseContext database { get; set; }

        public SubcategoryDAL(DatabaseContext db)
        {
            database = db;
            subcategorySet = database.Subcategories;
        }

        public List<Subcategory> GetSubcategories()
        {
            return subcategorySet.ToList();
        }

        public Subcategory GetSubcategory(int id)
        {
            throw new NotImplementedException();
        }

        public void AddSubcategory(string name)
        {
            Subcategory subcategory = new Subcategory() { Name = name };

            subcategorySet.Add(subcategory);
            database.SaveChanges();
        }

        public bool DoesSubcategoryAlreadyExist(string name)
        {
            return subcategorySet.Any(c => c.Name == name);
        }
    }
}
