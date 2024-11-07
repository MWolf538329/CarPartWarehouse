using Logic.Models;

namespace Logic.Interfaces
{
    public interface ISubcategoryDAL
    {
        // Read
        public List<Subcategory> GetSubcategories();
        public Subcategory GetSubcategory(int id);

        // Create
        public void AddSubcategory(string name);

        // Update
        public void EditSubcategory(int id, string name);

        // Delete
        public void DeleteSubcategory(int id);

        public bool DoesSubcategoryAlreadyExist(string name);
    }
}
