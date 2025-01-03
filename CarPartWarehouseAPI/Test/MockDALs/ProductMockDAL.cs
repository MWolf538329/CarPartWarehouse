using Logic.Interfaces;
using Logic.Models;

namespace Test.MockDALs;

public class ProductMockDAL : IProductDAL
{
    public bool IsUsed;
    public bool IsCreated;
    public bool IsUpdated;
    public bool IsDeleted;

    public List<Product> Products { get; } =
    [
        new()
        {
            ID = 1,
            Name = "Cilinderkop",
            Brand = "Kolbenschmidt",
            CurrentStock = 5,
            MinStock = 2,
            MaxStock = 7
        },
        new()
        {
            ID = 2,
            Name = "Handgeschakelde Transmissie met 3 Versnellingen zonder Motor",
            CurrentStock = 2,
            MinStock = 0,
            MaxStock = 2
        }
    ];
    
    public List<Product> GetProducts()
    {
        IsUsed = true;

        return Products;
    }

    public Product GetProduct(int productID)
    {
        IsUsed = true;

        return Products.FirstOrDefault(p => p.ID == productID)!;
    }

    public void CreateProduct(string name, string brand, int subcategoryID, int currentStock, int minStock, int maxStock)
    {
        IsUsed = true;
        
        Products.Add(new()
        {
            ID = 3,
            Name = "Remblokken",
            Brand = "Brembo",
            CurrentStock = 7,
            MinStock = 3,
            MaxStock = 10
        });

        if (Products.Count == 3)
        {
            IsCreated = true;
        }
    }

    public void UpdateProduct(int id, string name, string brand, int currentStock, int minStock, int maxStock)
    {
        IsUsed = true;

        Products[id].Name = name;
        Products[id].Brand = brand;
        Products[id].CurrentStock = currentStock;
        Products[id].MinStock = minStock;
        Products[id].MaxStock = maxStock;

        if (Products[id].Name == name && Products[id].Brand == brand && Products[id].CurrentStock == currentStock 
            && Products[id].MinStock == minStock && Products[id].MaxStock == maxStock)
        {
            IsUpdated = true;
        }
    }

    public void DeleteProduct(int id)
    {
        IsUsed = true;
        
        Products.RemoveAt(id);

        if (Products.Count == 1)
        {
            IsDeleted = true;
        }
    }

    public bool DoesProductAlreadyExist(string name, string brand)
    {
        return Products.Any(p => p.Name == name && p.Brand == brand);
    }

    public bool DoesProductIDExist(int id)
    {
        return Products.Any(p => p.ID == id);
    }
}