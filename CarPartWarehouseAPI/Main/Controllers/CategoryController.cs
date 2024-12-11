using CarPartWarehouseAPI.ViewModels;
using Logic.Interfaces;
using Logic.Models;
using Logic.Services;
using DAL.DALServices;
using DAL;

namespace CarPartWarehouseAPI.Services
{
    public static class CategoryController
    {
        public static RouteGroupBuilder SetupCategory(this RouteGroupBuilder group)
        {
            // Get All Categories
            group.MapGet("/", (DatabaseContext databaseContext) =>
            {
                ICategoryDAL categoryDAL = new CategoryDAL(databaseContext);
                CategoryService categoryService = new(categoryDAL);

                List<CategoryVM> categoryVMs = [];

                foreach (Category category in categoryService.GetCategories())
                {
                    CategoryVM categoryVM = new(category);

                    categoryVMs.Add(categoryVM);
                }

                return Results.Json(categoryVMs);
            })
            .WithName("GetCategories")
            .WithSummary("Gets All Categories")
            .WithDescription("Gets All Categories")
            .WithOpenApi();

            // Gets a specific Category
            group.MapGet("/{id}", (DatabaseContext databaseContext, int id) =>
            {
                ICategoryDAL categoryDAL = new CategoryDAL(databaseContext);
                CategoryService categoryService = new(categoryDAL);

                if (id == 0) return Results.BadRequest("Category ID can not be 0!");
                if (!categoryService.DoesCategoryIDExist(id)) return Results.NotFound("Category ID does not exist!");

                Category category = categoryService.GetCategory(id)!;

                CategoryWithSubcategoryVM categoryVM = new(category);

                return Results.Json(categoryVM);
            })
            .WithName("GetCategory")
            .WithSummary("Gets a Category")
            .WithDescription("Gets a Category")
            .WithOpenApi();
            
            // Create Category
            group
                .MapPost(
                    "/", 
                    (DatabaseContext databaseContext, string name) =>
                    {
                        ICategoryDAL categoryDAL = new CategoryDAL(databaseContext);
                        CategoryService categoryService = new(categoryDAL);

                        if (string.IsNullOrWhiteSpace(name)) 
                        {
                            return Results.BadRequest("Name can not be empty!");
                        }
                        if (categoryService.DoesCategoryAlreadyExist(name)) return Results.BadRequest("Category already exists!");

                        categoryService.CreateCategory(name);
                        return Results.Created();
                    })
                .WithName("CreateCategory")
                .WithSummary("Create Category")
                .WithDescription("Create Category")
                .WithOpenApi()
            ;


            // Update Category
            group.MapPut("/{id}", (DatabaseContext databaseContext, int id, string name) =>
            {
                ICategoryDAL categoryDAL = new CategoryDAL(databaseContext);
                CategoryService categoryService = new(categoryDAL);

                if (id == 0) return Results.BadRequest("Category ID can not be 0!");
                if (!categoryService.DoesCategoryIDExist(id)) return Results.NotFound("Category ID does not exist!");

                if (string.IsNullOrWhiteSpace(name)) return Results.BadRequest("Name can not be empty!");
                if (categoryService.DoesCategoryAlreadyExist(name)) return Results.BadRequest("Category already exists!");

                categoryService.UpdateCategory(id, name);
                return Results.Created();
            })
            .WithName("UpdateCategory")
            .WithSummary("Update Category")
            .WithDescription("Update Category")
            .WithOpenApi();


            // Delete Category
            group.MapDelete("/{id}", (DatabaseContext databaseContext, int id) =>
            {
                ICategoryDAL categoryDAL = new CategoryDAL(databaseContext);
                CategoryService categoryService = new(categoryDAL);

                if (id == 0) return Results.BadRequest("Category ID can not be 0!");
                if (!categoryService.DoesCategoryIDExist(id)) return Results.NotFound("Category ID does not exist!");

                categoryService.DeleteCategory(id);
                return Results.Ok("Category successfully Deleted!");
            })
            .WithName("DeleteCategory")
            .WithSummary("Delete Category")
            .WithDescription("Delete Category")
            .WithOpenApi();


            // Gets All Subcategories
            group.MapGet("/subcategories/", (DatabaseContext databaseContext) =>
            {
                ICategoryDAL categoryDAL = new CategoryDAL(databaseContext);
                CategoryService categoryService = new(categoryDAL);

                List<SubcategoryVM> subcategoryVMs = [];

                foreach (Subcategory subcategory in categoryService.GetSubcategories())
                {
                    SubcategoryVM subcategoryVM = new(subcategory);

                    subcategoryVMs.Add(subcategoryVM);
                }

                return Results.Json(subcategoryVMs);
            })
            .WithName("GetSubcategories")
            .WithSummary("Gets All Subcategories")
            .WithDescription("Gets All Subcategories")
            .WithOpenApi();


            // Subcategory POST
            group.MapPost("/{id}/subcategories/", (DatabaseContext databaseContext, int categoryID, string name) =>
            {
                ICategoryDAL categoryDAL = new CategoryDAL(databaseContext);
                CategoryService categoryService = new(categoryDAL);

                if (categoryID == 0) return Results.BadRequest("Category ID can not be 0!");
                if (!categoryService.DoesCategoryIDExist(categoryID)) return Results.NotFound("Category ID does not exist!");

                if (string.IsNullOrWhiteSpace(name)) return Results.BadRequest("Name can not be empty!");
                if (categoryService.DoesSubcategoryAlreadyExist(name)) return Results.BadRequest("Subcategory already exists!");

                categoryService.CreateSubcategory(categoryID, name);
                return Results.Created();
            })
            .WithName("CreateSubcategory")
            .WithSummary("Creates a Subcategory")
            .WithDescription("Creates a Subcategory")
            .WithOpenApi();


            // Subcategory PUT
            group.MapPut("/subcategory/{id}", (DatabaseContext databaseContext, int id, int categoryID, string name) =>
            {
                ICategoryDAL categoryDAL = new CategoryDAL(databaseContext);
                CategoryService categoryService = new(categoryDAL);

                if (id == 0) return Results.BadRequest("Subcategory ID can not be 0!");
                if (!categoryService.DoesSubcategoryIDExist(id)) return Results.NotFound("Subcategory ID does not exist!");

                if (categoryID == 0) return Results.BadRequest("category ID can not be 0!");
                if (!categoryService.DoesCategoryIDExist(categoryID)) return Results.NotFound("Category ID does not exist!");

                if (string.IsNullOrWhiteSpace(name)) return Results.BadRequest("Name can not be empty!");
                if (categoryService.DoesSubcategoryAlreadyExist(name)) return Results.BadRequest("Subcategory already exists!");

                categoryService.UpdateSubcategory(id, categoryID, name);
                return Results.Created();
            })
            .WithName("UpdateSubcategory")
            .WithSummary("Update Subcategory")
            .WithDescription("Update Subcategory")
            .WithOpenApi();


            // Subcategory DELETE
            group.MapDelete("/subcategory/{id}", (DatabaseContext databaseContext, int id) =>
            {
                ICategoryDAL categoryDAL = new CategoryDAL(databaseContext);
                CategoryService categoryService = new(categoryDAL);

                if (id == 0) return Results.BadRequest("Subcategory ID can not be 0!");
                if (!categoryService.DoesSubcategoryIDExist(id)) return Results.BadRequest("Subcategory ID does not exist!");

                categoryService.DeleteSubcategory(id);
                return Results.Ok("Subcategory successfully Deleted!");
            })
            .WithName("DeleteSubcategory")
            .WithSummary("Delete Subcategory")
            .WithDescription("Delete Subcategory")
            .WithOpenApi();


            // Categories / Subcategories / Products GET
            group.MapGet("/subcategories/products", (DatabaseContext databaseContext) =>
            {
                ICategoryDAL categoryDAL = new CategoryDAL(databaseContext);
                CategoryService categoryService = new(categoryDAL);

                List<CategoryWithSubcategoryVM> categoryVMs = [];

                foreach (Category category in categoryService.GetCategories())
                {
                    CategoryWithSubcategoryVM categoryVM = new(category);

                    categoryVMs.Add(categoryVM);
                }

                return Results.Json(categoryVMs);
            })
            .WithName("GetCategoriesSubcategoriesProducts")
            .WithSummary("Gets all Categories With Subcategories With Products")
            .WithDescription("Gets all Categories With Subcategories With Products")
            .WithOpenApi();


            return group;
        }
    }
}
