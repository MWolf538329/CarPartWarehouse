namespace DAL.DataModels
{
    public class StockHistoryDM
    {
        public int ID { get; set; }
        public DateTime StockChangeDate { get; set; }
        public int StockWas {  get; set; }
        public int StockNow {  get; set; }

        public ProductDM Product { get; set; }
    }
}
