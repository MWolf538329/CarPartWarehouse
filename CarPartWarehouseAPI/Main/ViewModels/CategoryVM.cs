using Logic.Models;

namespace CarPartWarehouseAPI.ViewModels
{
    public class CategoryVM(Category category)
    {
        public int ID { get; set; } = category.ID;
        public string Name { get; set; } = category.Name;
    }
}
