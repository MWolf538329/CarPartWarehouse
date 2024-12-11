using Logic.Interfaces;
using Logic.Models;

namespace Logic.Services
{
    public class SubcategoryService(ISubcategoryDAL subcategoryDal)
    {
        public List<Subcategory> GetSubcategories()
        {
            return subcategoryDal.GetSubcategories();
        }

        public bool AddSubcategory(string name)
        {
            bool succes = false;

            if (!subcategoryDal.DoesSubcategoryAlreadyExist(name))
            {
                subcategoryDal.AddSubcategory(name);
                succes = true;
            }

            return succes;
        }
    }
}
