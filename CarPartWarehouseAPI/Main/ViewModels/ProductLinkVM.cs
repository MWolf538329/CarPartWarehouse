using Logic.Models;

namespace CarPartWarehouseAPI.ViewModels
{
    public class ProductLinkVM
    {
        public int ID { get; set; }
        public string Url { get; set; }

        public ProductLinkVM(ProductLink productLink)
        {
            ID = productLink.ID;
            Url = productLink.Url;
        }
    }
}
