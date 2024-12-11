using Logic.Models;

namespace Logic.Interfaces
{
    public interface IProductDAL
    {
        public List<Product> GetProducts();
        public Product? GetProduct(int productID);
        public void CreateProduct(string name, string brand, int subcategoryID,
            int currentStock, int minStock, int maxStock);
        public void UpdateProduct(int id, string name, string brand, int subcategoryID,
            int currentStock, int minStock, int maxStock);
        public void DeleteProduct(int id);

        public bool DoesProductAlreadyExist(string name, string brand);
        public bool DoesProductIDExist(int id);
    }
}
