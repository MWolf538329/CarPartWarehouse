namespace CarPartWarehouseAPI.ViewModels
{
    public class CategoryVM
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public List<SubcategoryVM>? Subcategories { get; set; }
    }
}
