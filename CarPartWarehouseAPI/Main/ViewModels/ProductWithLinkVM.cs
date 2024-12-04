using Logic.Models;

namespace CarPartWarehouseAPI.ViewModels
{
    public class ProductWithLinkVM : ProductVM
    {
        public List<ProductLinkVM>? Links { get; set; } = new();

        public ProductWithLinkVM(Product product) : base(product)
        {
            if (product.Links != null && product.Links.Count != 0)
            {
                foreach (ProductLink productLink in product.Links)
                {
                    Links.Add(new(productLink));
                }
            }
        }
    }
}
