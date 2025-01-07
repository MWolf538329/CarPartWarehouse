using Logic.Interfaces;
using Logic.Models;

namespace Logic.Services;

public class ProductService(IProductDAL productDal, ICategoryDAL categoryDal)
{
    public List<Product> GetProducts()
    {
        return productDal.GetProducts();
    }

    public Product? GetProduct(int id)
    {
        return productDal.GetProduct(id);
    }

    public void CreateProduct(string name, string brand, int subcategoryID, int currentStock, int minStock, int maxStock)
    {
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(brand) ||
            DoesProductAlreadyExist(name, brand))
        {
            return;
        }

        if (subcategoryID == 0 || !categoryDal.DoesSubcategoryIDExist(subcategoryID))
        {
            return;
        }

        if (currentStock < 0 || minStock < 0 || maxStock < 0)
        {
            return;
        }

        productDal.CreateProduct(name, brand, subcategoryID, currentStock, minStock, maxStock);
    }

    public void UpdateProduct(int id, string name, string brand, int currentStock, int minStock, int maxStock)
    {
        if (id == 0 || !DoesProductIDExist(id))
        {
            return;
        }

        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(brand) ||
            DoesProductAlreadyExist(name, brand))
        {
            return;
        }
            
        if (currentStock < 0 || minStock < 0 || maxStock < 0)
        {
            return;
        }

        productDal.UpdateProduct(id, name, brand, currentStock, minStock, maxStock);
    }

    public void DeleteProduct(int id)
    {
        if (id == 0 || !DoesProductIDExist(id))
        {
            return;
        }

        productDal.DeleteProduct(id);
    }

    // ReSharper disable once MemberCanBePrivate.Global
    public bool DoesProductAlreadyExist(string name, string brand)
    {
        return productDal.DoesProductAlreadyExist(name, brand);
    }
    public bool DoesProductIDExist(int id)
    {
        return productDal.DoesProductIDExist(id);
    }
}