using Logic.Models;

namespace CarPartWarehouseAPI.ViewModels
{
    public class ProductVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Eurocents { get; set; }

        public StockVM Stock { get; set; }

        public Category Category { get; set; }
        public Subcategory Subcategory { get; set; }
        public List<ProductLink> Links { get; set; } = [];
    }
}
