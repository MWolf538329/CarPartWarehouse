using Logic.Models;

namespace CarPartWarehouseAPI.ViewModels
{
    public class ProductVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int CurrentStock { get; set; }
        public int MinStock { get; set; }
        public int MaxStock { get; set; }

        public ProductVM(Product product)
        {
            ID = product.ID;
            Name = product.Name;
            Brand = product.Brand;
            CurrentStock = product.CurrentStock;
            MinStock = product.MinStock;
            MaxStock = product.MaxStock;
        }
    }
}
