using Logic.Interfaces;
using Logic.Models;

namespace Logic.Services
{
    public class ProductService
    {
        readonly IProductDAL _ProductDAL;

        public ProductService(IProductDAL productDAL)
        {
            _ProductDAL = productDAL;
        }

        public List<Product> GetProducts()
        {
            return _ProductDAL.GetProducts();
        }
    }
}
