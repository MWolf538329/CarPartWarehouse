using Logic.Models;

namespace Logic.Interfaces
{
    public interface IStockHistoryDAL
    {
        // Read
        public List<StockHistory> GetStockHistoryOfProduct(int id);
    }
}
