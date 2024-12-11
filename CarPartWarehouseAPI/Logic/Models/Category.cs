namespace Logic.Models
{
    public class Category
    {
        public int ID { get; init; }
        public string Name { get; set; } = string.Empty;

        public virtual List<Subcategory>? Subcategories { get; init; }
    }
}