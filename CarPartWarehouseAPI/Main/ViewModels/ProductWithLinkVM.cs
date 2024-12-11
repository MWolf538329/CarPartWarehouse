using System.Text.Json.Serialization;
using Logic.Models;

namespace CarPartWarehouseAPI.ViewModels
{
    public class ProductWithLinkVM : ProductVM
    {
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
