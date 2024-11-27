namespace CarPartWarehouseAPI.ViewModels
{
    public class SubcategoryVM
    {
        public int ID { get; set; }
        public string Name { get; set; }


        public virtual CategoryVM Category { get; set; }
        public virtual List<ProductVM>? Products { get; set; }
    }
}
