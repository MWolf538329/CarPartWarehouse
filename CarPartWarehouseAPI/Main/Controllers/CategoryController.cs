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
        static DatabaseContext databaseContext;
        static ICategoryDAL categoryDAL;
        static CategoryService categoryService;

        static CategoryController()
        {
            databaseContext = new();
            categoryDAL = new CategoryDAL(databaseContext);
            categoryService = new(categoryDAL);
        }

        public static RouteGroupBuilder SetupCategory(this RouteGroupBuilder group)
        {
            // Get All Categories
            group.MapGet("/", () =>
            {
                List<CategoryVM> categoryVMs = new();

                foreach (Category category in categoryService.GetCategories())
                {
                    CategoryVM categoryVM = new();

                    categoryVM.ID = category.ID;
                    categoryVM.Name = category.Name;

                    categoryVMs.Add(categoryVM);
                }

                return Results.Json(categoryVMs);
            })
            .WithName("GetCategories")
            .WithOpenApi()
            .WithDescription("Gets the ID and Name from all Categories")
            .WithSummary("Gets the ID and Name from all Categories");

            // Gets a specific Category
            group.MapGet("/{categoryid}", (int categoryid) =>
            {
                if (!categoryService.DoesCategoryIDExist(categoryid))
                {
                    return Results.BadRequest("Category ID does not exist!");
                }

                Category category = categoryService.GetCategory(categoryid);

                CategoryVM categoryVM = new()
                {
                    ID = category.ID,
                    Name = category.Name
                };

                return Results.Json(categoryVM);
            })
            .WithName("GetCategory")
            .WithOpenApi()
            .WithDescription("Gets the ID and Name from a specific Category")
            .WithSummary("Gets the ID and Name from a specific Category");

            // Create Category
            group.MapPost("/", (string name) =>
            {
                if (string.IsNullOrEmpty(name))
                {
                    return Results.BadRequest("Name can not be empty!");
                }
                if (categoryService.DoesCategoryAlreadyExist(name))
                {
                    return Results.BadRequest("Category already exists!");
                }

                categoryService.AddCategory(name);
                return Results.Ok("Category Added!");
            })
            .WithName("AddCategory")
            .WithDescription("Creates a new Category and adds it to the Database")
            .WithSummary("Creates a new Category and adds it to the Database")
            .WithOpenApi();


            // Update Category
            group.MapPut("/{categoryid}", (int categoryid, string name) =>
            {
                if (categoryid == 0)
                {
                    return Results.BadRequest("Category ID can not be 0!");
                }
                if (string.IsNullOrEmpty(name))
                {
                    return Results.BadRequest("Name can not be empty!");
                }
                if (!categoryService.DoesCategoryIDExist(categoryid))
                {
                    return Results.BadRequest("Category ID does not exist!");
                }
                if (categoryService.DoesCategoryAlreadyExist(name))
                {
                    return Results.BadRequest("Category already exists!");
                }

                //categoryService.UpdateCategory(categoryID, name);
                return Results.Ok("Category succesfully Updated!");
            })
            .WithName("UpdateCategory")
            .WithDescription("Update an existing Category")
            .WithSummary("Update an existing Category")
            .WithOpenApi();

            // Delete Category


            // Gets All Subcategories
            group.MapGet("/subcategories/", () =>
            {
                List<SubcategoryVM> subcategoryVMs = new();

                foreach (Subcategory subcategory in categoryService.GetSubcategories())
                {
                    SubcategoryVM subcategoryVM = new();

                    subcategoryVM.ID = subcategory.ID;
                    subcategoryVM.Name = subcategory.Name;

                    subcategoryVMs.Add(subcategoryVM);
                }

                return Results.Json(subcategoryVMs);
            })
            .WithName("GetSubcategories")
            .WithOpenApi()
            .WithDescription("Gets the ID and Name from all Subcategories")
            .WithSummary("Gets the ID and Name from all Subcategories");

            // Gets All Subcategories from Category
            //group.MapGet("/{categoryid}/subcategories", (int categoryid) =>
            //{

            //});

            // Gets a specific Subcategory from Category
            //group.MapGet("/{categoryid}/subcategories/{subcategoryid}", (int categoryid, int subcategoryid) =>
            //{

            //});

            // Subcategory POST
            group.MapPost("/{categoryid}/", (int categoryid, string name) =>
            {
                if (categoryid == 0)
                {
                    return Results.BadRequest("Category ID can not be 0!");
                }
                if (string.IsNullOrEmpty(name))
                {
                    return Results.BadRequest("Name can not be empty!");
                }
                if (!categoryService.DoesCategoryIDExist(categoryid))
                {
                    return Results.BadRequest("Category ID does not exist!");
                }
                if (categoryService.DoesSubcategoryAlreadyExist(name))
                {
                    return Results.BadRequest("Subcategory already exists!");
                }

                categoryService.AddSubcategory(categoryid, name);
                return Results.Ok("Subcategory Added!");
            })
            .WithName("CreateSubcategory")
            .WithDescription("Creates a Subcategory")
            .WithSummary("Creates a Subcategory")
            .WithOpenApi();


            // Subcategory PUT
            group.MapPut("/subcategory/{subcategoryid}", (int subcategoryid, string name) =>
            {
                if (subcategoryid == 0)
                {
                    return Results.BadRequest("Subcategory ID can not be 0!");
                }
                if (string.IsNullOrEmpty(name))
                {
                    return Results.BadRequest("Name can not be empty!");
                }
                if (!categoryService.DoesSubcategoryIDExist(subcategoryid))
                {
                    return Results.BadRequest("Subcategory ID does not exist!");
                }
                if (categoryService.DoesSubcategoryAlreadyExist(name))
                {
                    return Results.BadRequest("Subcategory already exists!");
                }

                categoryService.UpdateSubcategory(subcategoryid, name);
                return Results.Ok("Subcategory Updated!");
            })
            .WithName("UpdateSubcategory")
            .WithDescription("Update an existing Subcategory")
            .WithSummary("Update an existing Subcategory")
            .WithOpenApi();

            // Subcategory DELETE





            return group;
        }
    }
}
