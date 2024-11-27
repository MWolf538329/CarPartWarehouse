using Logic.Interfaces;
using DAL.DALServices;
using Logic.Services;
using CarPartWarehouseAPI.ViewModels;
using Logic.Models;

namespace CarPartWarehouseAPI.Controllers
{
    public static class SubcategoryController
    {
        public static void SetupSubcategory(this WebApplication app)
        {
            //app.MapGet("/subcategories", (DAL.DatabaseContext databaseContext) =>
            //{
            //    ISubcategoryDAL subcategoryDAL = new SubcategoryDAL(databaseContext);
            //    SubcategoryService subcategoryService = new(subcategoryDAL);
            //    List<SubcategoryVM> subcategoryVMs = new();

            //    foreach (Subcategory subcategory in subcategoryService.GetSubcategories())
            //    {
            //        SubcategoryVM subcategoryVM = new SubcategoryVM();

            //        subcategoryVM.ID = subcategory.ID;
            //        subcategoryVM.Name = subcategory.Name;

            //        subcategoryVMs.Add(subcategoryVM);
            //    }

            //    return subcategoryVMs;
            //})
            //.WithName("GetSubcategories")
            //.WithOpenApi()
            //.WithDescription("Gets the ID and Name from all Subcategories");


            //app.MapPost("/addsubcategory", (DAL.DatabaseContext databaseContext, string name) =>
            //{
            //    ISubcategoryDAL subcategoryDAL = new SubcategoryDAL(databaseContext);
            //    SubcategoryService subcategoryService = new(subcategoryDAL);

            //    subcategoryService.CreateSubcategory(name);
            //})
            //.WithName("CreateSubcategory")
            //.WithOpenApi()
            //.WithDescription("Adds the new Subcategory to the Database");
        }
    }
}
