using CarPartWarehouseAPI.DataModels;
using CarPartWarehouseAPI.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CarPartWarehouseAPI.Services
{
    public static class ProductLinkService
    {
        public static void SetupProductLinks(this WebApplication app)
        {
            app.MapGet("/productlinks", (DatabaseContext db, int productID) =>
            {
                //List<ProductLinkDM> productLinks = (List<ProductLinkDM>)db.ProductLinks.Where(pl => pl.Product.ID == productID);

                //List<ProductLinkVM> productLinkViewModels = new();

                //foreach (ProductLinkDM productlink in productLinks)
                //{
                //    ProductLinkVM productLinkViewModel = new();

                //    productLinkViewModel.ID = productlink.ID;
                //    productLinkViewModel.Url = productlink.Url;

                //    productLinkViewModels.Add(productLinkViewModel);
                //}
                //return productLinkViewModels;
            })
            .WithName("GetProductLinks")
            .WithOpenApi();
        }
    }
}
