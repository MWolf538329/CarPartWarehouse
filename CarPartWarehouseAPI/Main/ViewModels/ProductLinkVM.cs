using Logic.Models;

namespace CarPartWarehouseAPI.ViewModels
{
    public class ProductLinkVM(ProductLink productLink)
    {
        public int ID { get; set; } = productLink.ID;
        public string Url { get; set; } = productLink.Url;
    }
}
