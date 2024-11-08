using Logic.Interfaces;
using Logic.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.DALServices
{
    public class ProductDAL : IProductDAL
    {
        private DbSet<Product> productSet { get; set; }
        private DatabaseContext database { get; set; }

        public ProductDAL(DatabaseContext databaseContext)
        {
            database = databaseContext;
            productSet = database.Products;
        }

        public List<Product> GetProducts()
        {
            return productSet.ToList();
        }

        public void AddProduct(string name, string brand, int eurocents, int subcategoryID, int? currentStock, int? minStock, int? maxStock, List<string>? productLinks)
        {
            productSet.Add(new Product() { Name = name, Brand = brand, Eurocents = eurocents, 
                Subcategory = new Subcategory() { ID = subcategoryID } });
        }

        public void EditProduct(int id, string name, string brand, int eurocents, int subcategoryID, List<string>? productLinks)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }
        

        public bool DoesProductAlreadyExist(string name, string brand)
        {
            throw new NotImplementedException();
        }
    }
}
