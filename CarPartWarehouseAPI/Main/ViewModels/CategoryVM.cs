using Logic.Models;

namespace CarPartWarehouseAPI.ViewModels
{
    public class CategoryVM
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public CategoryVM(Category category)
        {
            ID = category.ID;
            Name = category.Name;
        }
    }
}
