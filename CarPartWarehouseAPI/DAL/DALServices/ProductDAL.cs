using Logic.Interfaces;
using Logic.Models;

namespace DAL.DALServices
{
    public class ProductDAL : IProductDAL
    {
        private DatabaseContext database { get; set; }

        public ProductDAL(DatabaseContext databaseContext)
        {
            database = databaseContext;
        }

        public List<Product> GetProducts()
        {
            return database.Products.ToList();
        }

        public Product? GetProduct(int id)
        {
            return database.Products.Where(p => p.ID == id).FirstOrDefault();
        }

        public void CreateProduct(string name, string brand, int subcategoryID,
            int currentStock, int minStock,int maxStock)
        {
            Subcategory? subcategory = database.Subcategories.Where(sc => sc.ID == subcategoryID).FirstOrDefault();

            if (subcategory == null) return;

            database.Products.Add(new Product()
            {
                Name = name,
                Brand = brand,
                Subcategory = subcategory,
                CurrentStock = currentStock,
                MinStock = minStock,
                MaxStock = maxStock
            });
            database.SaveChanges();
        }

        public void UpdateProduct(int id, string name, string brand, int subcategoryID,
            int currentStock, int minStock, int maxStock)
        {
            if (id == 0 || !DoesProductIDExist(id)) return;
            if (string.IsNullOrEmpty(name)) return;
            if (string.IsNullOrEmpty(brand)) return;

            Subcategory? subcategory = database.Subcategories.Where(sc => sc.ID == subcategoryID).FirstOrDefault();

            if (subcategory == null) return;

            if (currentStock < 0) return;
            if (minStock < 0) return;
            if (maxStock < 0) return;

            Product product = database.Products.Where(p => p.ID == id).FirstOrDefault()!;
            product.Name = name;
            product.Brand = brand;
            product.Subcategory = subcategory;
            product.CurrentStock = currentStock;
            product.MinStock = minStock;
            product.MaxStock = maxStock;

            database.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            if (id == 0 || !DoesProductIDExist(id)) return;

            database.Products.Remove(database.Products.Where(p => p.ID == id).FirstOrDefault()!);
            database.SaveChanges();
        }

        public bool DoesProductAlreadyExist(string name, string brand)
        {
            return database.Products.Any(p => p.Name == name && p.Brand == brand);
        }
        public bool DoesProductIDExist(int id)
        {
            return database.Products.Any(p => p.ID == id);
        }
    }
}
