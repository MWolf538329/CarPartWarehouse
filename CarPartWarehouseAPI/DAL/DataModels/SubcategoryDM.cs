namespace DAL.DataModels
{
    public class SubcategoryDM
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public CategoryDM Category { get; set; }
    }
}
