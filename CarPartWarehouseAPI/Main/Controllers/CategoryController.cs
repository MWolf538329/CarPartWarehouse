using CarPartWarehouseAPI.ViewModels;
using Logic.Interfaces;
using Logic.Models;
using Logic.Services;
using DAL;
using DAL.DALServices;

namespace CarPartWarehouseAPI.Services
{
    public static class CategoryController
    {
        public static void SetupCategory(this WebApplication app)
        {
            app.MapGet("/categories", (DatabaseContext databaseContext) =>
            {
                ICategoryDAL categoryDAL = new CategoryDAL(databaseContext);
                CategoryService categoryService = new(categoryDAL);
                List<CategoryVM> categoryVMs = new();

                foreach (Category category in categoryService.GetCategories())
                {
                    CategoryVM categoryVM = new();

                    categoryVM.ID = category.ID;
                    category.Name = category.Name;

                    categoryVMs.Add(categoryVM);
                }

                return categoryVMs;
            })
            .WithName("GetCategories")
            .WithOpenApi()
            .WithDescription("Gets the ID and Name from all Categories");


            app.MapPost("/addcategory", (DatabaseContext databaseContext, string name) =>
            {
                ICategoryDAL categoryDAL = new CategoryDAL(databaseContext);
                CategoryService categoryService = new(categoryDAL);

                categoryService.AddCategory(name);
            })
            .WithName("AddCategory")
            .WithOpenApi()
            .WithDescription("Adds the new Category to the Database");
        }
    }
}
