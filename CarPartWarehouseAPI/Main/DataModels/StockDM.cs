namespace CarPartWarehouseAPI.DataModels
{
    public class StockDM
    {
        public int ID { get; set; }
        public int CurrentStock { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
    }
}
