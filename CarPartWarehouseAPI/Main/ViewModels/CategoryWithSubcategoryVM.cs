using Logic.Models;

namespace CarPartWarehouseAPI.ViewModels
{
    public class CategoryWithSubcategoryVM : CategoryVM
    {
        public List<SubcategoryWithProductVM>? Subcategories { get; set; } = new();

        public CategoryWithSubcategoryVM(Category category) : base(category)
        {
            if (category.Subcategories != null && category.Subcategories.Count != 0)
            {
                foreach (Subcategory subcategory in category.Subcategories)
                {
                    Subcategories.Add(new(subcategory));
                }
            }
        }
    }
}
