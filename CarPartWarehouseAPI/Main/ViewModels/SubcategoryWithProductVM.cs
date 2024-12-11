using System.Text.Json.Serialization;
using Logic.Models;

namespace CarPartWarehouseAPI.ViewModels
{
    public class SubcategoryWithProductVM : SubcategoryVM
    {
        [JsonInclude]
        public List<ProductVM> Products { get; set; } = [];

        public SubcategoryWithProductVM(Subcategory subcategory) : base(subcategory)
        {
            if (subcategory.Products == null || subcategory.Products.Count == 0) return;
            
            foreach (Product product in subcategory.Products)
            {
                Products.Add(new ProductVM(product));
            }
        }
    }
}
