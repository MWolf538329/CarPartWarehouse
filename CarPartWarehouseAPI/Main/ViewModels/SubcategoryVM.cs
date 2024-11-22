namespace CarPartWarehouseAPI.ViewModels
{
    public class SubcategoryVM
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public List<ProductVM>? Products { get; set; }
    }
}
