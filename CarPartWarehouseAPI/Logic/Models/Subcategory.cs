namespace Logic.Models
{
    public class Subcategory
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual Category Category { get; set; }

        public virtual List<Product>? Products { get; set; }
    }
}
