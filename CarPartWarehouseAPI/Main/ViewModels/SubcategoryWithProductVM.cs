using Logic.Models;

namespace CarPartWarehouseAPI.ViewModels
{
    public class SubcategoryWithProductVM : SubcategoryVM
    {
        public List<ProductVM>? Products { get; set; } = new();

        public SubcategoryWithProductVM(Subcategory subcategory) : base(subcategory)
        {
            if (subcategory.Products != null && subcategory.Products.Count != 0)
            {
                foreach (Product product in subcategory.Products)
                {
                    Products.Add(new(product));
                }
            }
        }
    }
}
