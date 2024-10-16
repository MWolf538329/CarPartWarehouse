namespace DAL.DataModels
{
    public class ProductDM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }

        public CategoryDM Category { get; set; }
        public SubcategoryDM Subcategory { get; set; }
        public List<ProductLinkDM> Links { get; set; } = [];
    }
}
