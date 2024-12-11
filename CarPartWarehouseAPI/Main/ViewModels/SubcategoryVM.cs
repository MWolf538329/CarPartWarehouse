using Logic.Models;

namespace CarPartWarehouseAPI.ViewModels
{
    public class SubcategoryVM(Subcategory subcategory)
    {
        public int ID { get; set; } = subcategory.ID;
        public string Name { get; set; } = subcategory.Name;
    }
}
