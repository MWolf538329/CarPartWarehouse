using System.Text.Json.Serialization;
using Logic.Models;

namespace CarPartWarehouseAPI.ViewModels
{
    /// <summary>
    /// Represents a Product with ProductLink in the system
    /// </summary>
    public class ProductWithLinkVM : ProductVM
    {
        /// <summary>
        /// Gets or sets the ProductLinks belonging to the Product
        /// </summary>
        [JsonInclude]
        public List<ProductLinkVM> Links { get; set; } = [];

        public ProductWithLinkVM(Product product) : base(product)
        {
            if (product.Links.Count == 0) return;
            
            foreach (ProductLink productLink in product.Links)
            {
                Links.Add(new ProductLinkVM(productLink));
            }
        }
    }
}
