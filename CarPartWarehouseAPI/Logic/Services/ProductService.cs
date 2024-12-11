using Logic.Interfaces;
using Logic.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logic.Services
{
    public class ProductService
    {
        readonly IProductDAL _ProductDAL;
        readonly ICategoryDAL _CategoryDAL;

        public ProductService(IProductDAL productDAL, ICategoryDAL categoryDAL)
        {
            _ProductDAL = productDAL;
            _CategoryDAL = categoryDAL;
        }

        public List<Product> GetProducts()
        {
            return _ProductDAL.GetProducts();
        }

        public Product? GetProduct(int id)
        {
            return _ProductDAL.GetProduct(id);
        }

        public void CreateProduct(string name, string brand, int subcategoryID, int currentStock, int minStock, int maxStock)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(brand) || DoesProductAlreadyExist(name, brand)) return;
            if (subcategoryID == 0 || !_CategoryDAL.DoesSubcategoryIDExist(subcategoryID)) return;
            if (currentStock < 0) return;
            if (minStock < 0) return;
            if (maxStock < 0) return;

            _ProductDAL.CreateProduct(name, brand, subcategoryID, currentStock, minStock, maxStock);
        }

        public void UpdateProduct(int id, string name, string brand, int subcategoryID, int currentStock, int minStock, int maxStock)
        {
            if (id == 0 || DoesProductIDExist(id)) return;
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(brand) || DoesProductAlreadyExist(name, brand)) return;
            if (subcategoryID == 0 || !_CategoryDAL.DoesSubcategoryIDExist(subcategoryID)) return;
            if (currentStock < 0) return;
            if (minStock < 0) return;
            if (maxStock < 0) return;

            _ProductDAL.UpdateProduct(id, name, brand, subcategoryID, currentStock, minStock, maxStock);
        }

        public void DeleteProduct(int id)
        {
            if (id == 0 || !DoesProductIDExist(id)) return;

            _ProductDAL.DeleteProduct(id);
        }

        public bool DoesProductAlreadyExist(string name, string brand)
        {
            return _ProductDAL.DoesProductAlreadyExist(name, brand);
        }
        public bool DoesProductIDExist(int id)
        {
            return _ProductDAL.DoesProductIDExist(id);
        }
    }
}
