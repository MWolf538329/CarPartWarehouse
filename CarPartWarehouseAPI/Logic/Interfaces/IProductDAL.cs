using Logic.Models;

namespace Logic.Interfaces
{
    public interface IProductDAL
    {
        // Read
        public List<Product> GetProducts();

        // Create
        public void AddProduct(string name, string brand, int eurocents, int subcategoryID,
            int? currentStock, int? minStock, int? maxStock, List<string>? productLinks);

        // Update
        public void EditProduct(int id, string name, string brand, int eurocents, int subcategoryID, List<string>? productLinks);

        // Delete
        public void DeleteProduct(int id);

        public bool DoesProductAlreadyExist(string name, string brand);
    }
}
