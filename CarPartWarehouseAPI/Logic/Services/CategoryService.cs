using Logic.Interfaces;
using Logic.Models;

namespace Logic.Services
{
    public class CategoryService
    {
        readonly ICategoryDAL _CategoryDAL;

        public CategoryService(ICategoryDAL categoryDAL) 
        {
            _CategoryDAL = categoryDAL;
        }

        public List<Category> GetCategories()
        {
            return _CategoryDAL.GetCategories();
        }

        public Category GetCategory(int id)
        {
            return _CategoryDAL.GetCategory(id);
        }

        public bool AddCategory(string name)
        {
            bool succes = false;

            if (!_CategoryDAL.DoesCategoryAlreadyExist(name))
            {
                _CategoryDAL.AddCategory(name);
                succes = true;
            }

            return succes;
        }
    }
}
