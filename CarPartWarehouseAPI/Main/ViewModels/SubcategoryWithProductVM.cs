using System.Text.Json.Serialization;
using Logic.Models;

namespace CarPartWarehouseAPI.ViewModels
{
    /// <summary>
    /// Represents a Subcategory with Products
    /// </summary>
    public class SubcategoryWithProductVM : SubcategoryVM
    {
        /// <summary>
        /// Gets or sets the Products belonging to the Subcategory
        /// </summary>
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
