namespace Logic.Interfaces
{
    public interface IStockDAL
    {
        // Read
        public void GetStockOfProduct(int productID);

        // Update
        public void EditStockOfProduct(int stockID, int currentStock, int minStock, int maxStock);
    }
}
