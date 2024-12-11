using Logic.Models;

namespace CarPartWarehouseAPI.ViewModels
{
    public class ProductVM(Product product)
    {
        public int ID { get; set; } = product.ID;
        public string Name { get; set; } = product.Name;
        public string Brand { get; set; } = product.Brand;
        public int CurrentStock { get; set; } = product.CurrentStock;
        public int MinStock { get; set; } = product.MinStock;
        public int MaxStock { get; set; } = product.MaxStock;
    }
}
