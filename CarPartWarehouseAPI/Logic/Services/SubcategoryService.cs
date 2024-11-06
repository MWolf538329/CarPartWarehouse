using Logic.Interfaces;
using Logic.Models;

namespace Logic.Services
{
    public class SubcategoryService
    {
        readonly ISubcategoryDAL _SubcategoryDAL;

        public SubcategoryService(ISubcategoryDAL subcategoryDAL)
        {
            _SubcategoryDAL = subcategoryDAL;
        }

        public List<Subcategory> GetSubcategories()
        {
            return _SubcategoryDAL.GetSubcategories();
        }

        public bool AddSubcategory(string name)
        {
            bool succes = false;

            if (!_SubcategoryDAL.DoesSubcategoryAlreadyExist(name))
            {
                _SubcategoryDAL.AddSubcategory(name);
                succes = true;
            }

            return succes;
        }
    }
}
