using DAL.DataModels;
using Logic.Interfaces;
using Logic.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.DALServices
{
    public class ProductDAL(DatabaseContext databaseContext) : IProductDAL
    {
        private DatabaseContext database { get; set; } = databaseContext;

        public List<Product> GetProducts()
        {
            List<ProductDTO> productDTOs = database.Products.Include(productDto => productDto.Subcategory!)
                .Include(productDto => productDto.Links).ToList();

            List<Product> products = [];

            foreach (ProductDTO productDTO in productDTOs)
            {
                Product product = new()
                {
                    ID = productDTO.ID,
                    Name = productDTO.Name,
                    Brand = productDTO.Brand,
                    CurrentStock = productDTO.CurrentStock,
                    MinStock = productDTO.MinStock,
                    MaxStock = productDTO.MaxStock,
                    Subcategory = new Subcategory
                    {
                        ID = productDTO.Subcategory.ID,
                        Name = productDTO.Subcategory.Name,
                    },
                };

                foreach (ProductLinkDTO linkDTO in productDTO.Links)
                {
                    product.Links.Add(new ProductLink()
                    {
                        ID = linkDTO.ID,
                        Url = linkDTO.Url
                    });
                }                

                products.Add(product);
            }
            
            return products;
        }

        public Product? GetProduct(int id)
        {
            if (!DoesProductIDExist(id))
            {
                return null;
            }
            
            ProductDTO? productDTO = database.Products.Include(productDto => productDto.Subcategory)
                .Include(productDto => productDto.Links).FirstOrDefault(p => p.ID == id);

            Product product = new()
            {
                ID = productDTO!.ID,
                Name = productDTO.Name,
                Brand = productDTO.Brand,
                CurrentStock = productDTO.CurrentStock,
                MinStock = productDTO.MinStock,
                MaxStock = productDTO.MaxStock,
                Subcategory = new Subcategory()
                {
                    ID = productDTO.Subcategory.ID,
                    Name = productDTO.Subcategory.Name,
                },
            };

            foreach (ProductLinkDTO linkDTO in productDTO.Links)
            {
                product.Links.Add(new ProductLink()
                {
                    ID = linkDTO.ID,
                    Url = linkDTO.Url
                });
            }

            return product;
        }

        public void CreateProduct(string name, string brand, int subcategoryID,
            int currentStock, int minStock, int maxStock, List<string>? productLinks)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(brand))
            {
                return;
            }

            if (currentStock < 0 || minStock < 0 || maxStock < 0)
            {
                return;
            }

            CategoryDAL categoryDAL = new(database);
            if (!categoryDAL.DoesSubcategoryIDExist(subcategoryID))
            {
                return;
            }
            
            SubcategoryDTO? subcategory = database.Subcategories.FirstOrDefault(sc => sc.ID == subcategoryID);

            ProductDTO productDTO = new()
            {
                Name = name,
                Brand = brand,
                Subcategory = subcategory!,
                CurrentStock = currentStock,
                MinStock = minStock,
                MaxStock = maxStock
            };

            // Product Links still need to be figured out and implemented.
            // if (productLinks.Count != 0)
            // {
            //     foreach (ProductLink productLink in productLinks)
            //     {
            //         ProductLinkDTO productLinkDTO = new()
            //         {
            //             ID = productLink.ID,
            //             Url = productLink.Url,
            //         };
            //         
            //         productDTO.Links.Add(productLinkDTO);
            //     }
            // }
            
            database.Products.Add(productDTO);
            database.SaveChanges();
        }

        public void UpdateProduct(int id, string name, string brand, int subcategoryID,
            int currentStock, int minStock, int maxStock, List<string>? productLinks)
        {
            if (id == 0 || !DoesProductIDExist(id))
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(brand))
            {
                return;
            }

            if (currentStock < 0 || minStock < 0 || maxStock < 0)
            {
                return;
            }

            CategoryDAL categoryDAL = new(database);
            if (!categoryDAL.DoesSubcategoryIDExist(subcategoryID))
            {
                return;
            }
            
            ProductDTO productDTO = database.Products.Include(productDto => productDto.Links)
                .FirstOrDefault(p => p.ID == id)!;
            
            productDTO.Name = name;
            productDTO.Brand = brand;
            productDTO.SubcategoryID = subcategoryID;
            productDTO.CurrentStock = currentStock;
            productDTO.MinStock = minStock;
            productDTO.MaxStock = maxStock;
            
            // Product Links still need to be figured out and implemented.

            database.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            if (id == 0 || !DoesProductIDExist(id))
            {
                return;
            }

            database.Products.Remove(database.Products.FirstOrDefault(p => p.ID == id)!);
            database.SaveChanges();
        }

        public bool DoesProductAlreadyExist(string name, string brand)
        {
            return database.Products.Any(p => p.Name == name && p.Brand == brand);
        }
        public bool DoesProductIDExist(int id)
        {
            return database.Products.Any(p => p.ID == id);
        }
    }
}
