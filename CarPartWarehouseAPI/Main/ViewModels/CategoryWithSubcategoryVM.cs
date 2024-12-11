using System.Text.Json.Serialization;
using Logic.Models;

namespace CarPartWarehouseAPI.ViewModels
{
    public class CategoryWithSubcategoryVM : CategoryVM
    {
        [JsonInclude]
        public List<SubcategoryWithProductVM> Subcategories { get; set; } = [];

        public CategoryWithSubcategoryVM(Category category) : base(category)
        {
            if (category.Subcategories == null || category.Subcategories.Count == 0) return;
            
            foreach (Subcategory subcategory in category.Subcategories)
            {
                Subcategories.Add(new SubcategoryWithProductVM(subcategory));
            }
        }
    }
}
