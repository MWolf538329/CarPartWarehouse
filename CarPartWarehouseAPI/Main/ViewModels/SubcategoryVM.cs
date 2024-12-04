using Logic.Models;

namespace CarPartWarehouseAPI.ViewModels
{
    public class SubcategoryVM
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public SubcategoryVM(Subcategory subcategory)
        {
            ID = subcategory.ID;
            Name = subcategory.Name;
        }
    }
}
