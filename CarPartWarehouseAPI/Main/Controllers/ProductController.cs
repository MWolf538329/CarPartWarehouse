using CarPartWarehouseAPI.ViewModels;
using Logic.Interfaces;
using Logic.Models;
using Logic.Services;
using DAL.DALServices;
using DAL;

namespace CarPartWarehouseAPI.Controllers
{
    public static class ProductController
    {
        static DatabaseContext databaseContext;
        static IProductDAL productDAL;
        static ProductService productService;

        static ProductController()
        {
            databaseContext = new();
            productDAL = new ProductDAL(databaseContext);
            productService = new(productDAL);
        }

        public static RouteGroupBuilder SetupProduct(this RouteGroupBuilder group)
        {
            // Get ALL Products
            group.MapGet("/", () =>
            {
                List<ProductVM> productVMs = new();

                foreach (Product product in productService.GetProducts())
                {
                    ProductVM productVM = new();

                    productVM.ID = product.ID;
                    productVM.Name = product.Name;
                    productVM.Brand = product.Brand;
                    productVM.Eurocents = product.Eurocents;

                    productVM.Subcategory = new()
                    {
                        ID = product.Subcategory.ID,
                        Name = product.Subcategory.Name,
                        Category = new()
                        {
                            ID = product.Subcategory.Category.ID,
                            Name = product.Subcategory.Category.Name
                        }
                    };

                    productVM.Stock = new()
                    {
                        ID = product.Stock.ID,
                        CurrentStock = product.Stock.CurrentStock,
                        Min = product.Stock.Min,
                        Max = product.Stock.Max
                    };

                    productVMs.Add(productVM);
                }

                return Results.Json(productVMs);
            })
            .WithName("GetProducts")
            .WithOpenApi()
            .WithDescription("Gets the ID, Name, Brand, Subcategory ID and Name, Category ID and Name and Stock from all Products")
            .WithSummary("Gets the ID, Name, Brand, Subcategory ID and Name, Category ID and Name and Stock from all Products");


            // Create Product
            group.MapGet("/", 
            (
                string productName, string productBrand, int productEurocents, 
                int subcategoryID, 
                int currentStock, int minStock, int maxStock
            ) => 
            {
                if (!string.IsNullOrEmpty(productName))
                    return Results.BadRequest("Product Name can not be empty!");

                if (!string.IsNullOrEmpty(productBrand))
                    return Results.BadRequest("Product Brand can not be empty!");

                if (productEurocents == 0)
                    return Results.BadRequest("Product Eurocents can not be 0!");

                if (subcategoryID == 0)
                    return Results.BadRequest("Subcategory can not be empty!");

                //productService.CreateProduct();
                return Results.Ok("Product succesfully Created!");
            });

            return group;
        }
    }
}
