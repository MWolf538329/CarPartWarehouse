namespace Logic.Models
{
    public class Subcategory
    {
        public int ID { get; init; }
        public string Name { get; set; } = string.Empty;

        public virtual Category Category { get; init; }

        public virtual List<Product>? Products { get; init; }
    }
}
