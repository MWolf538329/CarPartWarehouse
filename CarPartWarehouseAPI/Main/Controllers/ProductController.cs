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
                    productVM.Subcategory = product.Subcategory;

                    productVMs.Add(productVM);
                }

                return Results.Json(productVMs);
            })
            .WithName("GetProducts")
            .WithOpenApi()
            .WithDescription("Gets the ID, Name, Brand, Subcategory ID and Name, Category ID and Name and Stock  from all Categories")
            .WithSummary("Gets the ID and Name from all Categories");

            return group;
        }
    }
}
