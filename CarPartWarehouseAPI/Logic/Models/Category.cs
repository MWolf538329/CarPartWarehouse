namespace Logic.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual List<Subcategory>? Subcategories { get; set; }
    }
}