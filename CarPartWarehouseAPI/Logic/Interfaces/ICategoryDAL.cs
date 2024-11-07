using Logic.Models;

namespace Logic.Interfaces
{
    public interface ICategoryDAL
    {
        // Read
        public List<Category> GetCategories();
        public Category GetCategory(int id);

        // Create
        public void AddCategory(string name);

        // Update
        public void EditCategory(int id, string name);

        // Delete
        public void DeleteCategory(int id);

        public bool DoesCategoryAlreadyExist(string name);
    }
}
