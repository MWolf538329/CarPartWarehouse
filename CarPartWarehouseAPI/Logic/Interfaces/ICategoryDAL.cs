using Logic.Models;

namespace Logic.Interfaces
{
    public interface ICategoryDAL
    {
        public List<Category> GetCategories();
        public Category GetCategory(int id);
        public bool DoesCategoryAlreadyExist(string name);

        public void AddCategory(string name);
    }
}
