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
        public static RouteGroupBuilder SetupProduct(this RouteGroupBuilder group)
        {
            group.MapGet("/", (DatabaseContext databaseContext) =>
            {
                IProductDAL productDAL = new ProductDAL(databaseContext);
                ICategoryDAL categoryDAL = new CategoryDAL(databaseContext);
                ProductService productService = new(productDAL, categoryDAL);

                List<ProductVM> productVMs = [];

                foreach (Product product in productService.GetProducts())
                {
                    ProductVM productVM = new(product);

                    productVMs.Add(productVM);
                }

                return Results.Json(productVMs);
            })
            .WithName("GetProducts")
            .WithSummary("Gets All Products")
            .WithDescription("Gets All Products")
            .WithOpenApi();

            group.MapGet("/{id}", (DatabaseContext databaseContext, int id) =>
            {
                IProductDAL productDAL = new ProductDAL(databaseContext);
                ICategoryDAL categoryDAL = new CategoryDAL(databaseContext);
                ProductService productService = new(productDAL, categoryDAL);

                if (id == 0) return Results.BadRequest("Product ID can not be 0!");
                if (!productService.DoesProductIDExist(id)) return Results.NotFound("Product ID does not Exist!");

                Product product = productService.GetProduct(id)!;
                
                ProductWithLinkVM productVM = new(product);
                return Results.Json(productVM);
            })
            .WithName("GetProduct")
            .WithSummary("Gets a Product")
            .WithDescription("Gets a Product")
            .WithOpenApi();


            group.MapPost("/", (DatabaseContext databaseContext, string name, string brand,
                int subcategoryID, int currentStock, int minStock, int maxStock) => 
            {
                IProductDAL productDAL = new ProductDAL(databaseContext);
                ICategoryDAL categoryDAL = new CategoryDAL(databaseContext);
                ProductService productService = new(productDAL, categoryDAL);
                CategoryService categoryService = new(categoryDAL);

                if (string.IsNullOrEmpty(name)) return Results.BadRequest("Product Name can not be empty!");

                if (string.IsNullOrEmpty(brand)) return Results.BadRequest("Product Brand can not be empty!");

                if (subcategoryID == 0) return Results.BadRequest("Subcategory can not be empty!");
                if (!categoryService.DoesSubcategoryIDExist(subcategoryID)) return Results.NotFound("Subcategory does not exist!");

                if (currentStock < 0) return Results.BadRequest("Current Stock can not be lower than 0!");

                if (minStock < 0) return Results.BadRequest("Min Stock can not be lower than 0!");

                if (maxStock < 0) return Results.BadRequest("Max Stock can not be lower than 0!");


                productService.CreateProduct(name, brand, subcategoryID, currentStock, minStock, maxStock);
                return Results.Created();
            })
            .WithName("CreateProduct")
            .WithSummary("Create Product")
            .WithDescription("Create Product")
            .WithOpenApi();


            group.MapPut("/{id}", (DatabaseContext databaseContext, int id, string name, string brand,
                int subcategoryID, int currentStock, int minStock, int maxStock) =>
            {
                IProductDAL productDAL = new ProductDAL(databaseContext);
                ICategoryDAL categoryDAL = new CategoryDAL(databaseContext);
                ProductService productService = new(productDAL, categoryDAL);
                CategoryService categoryService = new(categoryDAL);

                if (id == 0) return Results.BadRequest("ID can not be 0!");
                if (!productService.DoesProductIDExist(id)) return Results.NotFound("Product ID does not Exist!");

                if (string.IsNullOrEmpty(name)) return Results.BadRequest("Product Name can not be empty!");

                if (string.IsNullOrEmpty(brand)) return Results.BadRequest("Product Brand can not be empty!");

                if (subcategoryID == 0) return Results.BadRequest("Subcategory can not be empty!");
                if (!categoryService.DoesSubcategoryIDExist(subcategoryID)) return Results.NotFound("Subcategory does not exist!");

                if (currentStock < 0) return Results.BadRequest("Current Stock can not be lower than 0!");

                if (minStock < 0) return Results.BadRequest("Min Stock can not be lower than 0!");

                if (maxStock < 0) return Results.BadRequest("Max Stock can not be lower than 0!");


                productService.UpdateProduct(id, name, brand, subcategoryID, currentStock, minStock, maxStock);
                return Results.Created();
            })
            .WithName("UpdateProduct")
            .WithSummary("Update Product")
            .WithDescription("Update Product")
            .WithOpenApi();


            group.MapDelete("{id}", (DatabaseContext databaseContext, int id) =>
            {
                IProductDAL productDAL = new ProductDAL(databaseContext);
                ICategoryDAL categoryDAL = new CategoryDAL(databaseContext);
                ProductService productService = new(productDAL, categoryDAL);

                if (id == 0) return Results.BadRequest("ID can not be 0!");
                if (!productService.DoesProductIDExist(id)) return Results.NotFound("Product ID does not Exist!");

                productService.DeleteProduct(id);
                return Results.Ok("Product Successfully Deleted!");
            })
            .WithName("DeleteProduct")
            .WithSummary("Delete Product")
            .WithDescription("Delete Product")
            .WithOpenApi();


            return group;
        }
    }
}
