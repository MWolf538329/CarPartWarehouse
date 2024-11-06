using Logic.Models;

namespace Logic.Interfaces
{
    public interface ISubcategoryDAL
    {
        public List<Subcategory> GetSubcategories();
        public Subcategory GetSubcategory(int id);
        public bool DoesSubcategoryAlreadyExist(string name);
        public void AddSubcategory(string name);
    }
}
