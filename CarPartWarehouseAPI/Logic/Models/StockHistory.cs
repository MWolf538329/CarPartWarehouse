namespace Logic.Models
{
    public class StockHistory
    {
        public int ID { get; set; }
        public DateTime StockChangeDate { get; set; }
        public int StockWas {  get; set; }
        public int StockNow {  get; set; }

        public virtual Product Product { get; set; }
    }
}
