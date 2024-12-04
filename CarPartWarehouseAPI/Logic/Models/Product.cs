namespace Logic.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int CurrentStock { get; set; }
        public int MinStock { get; set; }
        public int MaxStock { get; set; }

        public virtual Subcategory Subcategory { get; set; }
        public virtual List<ProductLink> Links { get; set; } = [];
    }
}
