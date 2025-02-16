﻿using DAL.DataModels;
using Logic.Interfaces;
using Logic.Models;
using Microsoft.EntityFrameworkCore;
// ReSharper disable ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
#pragma warning disable CS8602 // Dereference of a possibly null reference.

namespace DAL.DALServices;

public class ProductDAL(DatabaseContext databaseContext) : IProductDAL
{
    private DatabaseContext database { get; } = databaseContext;

    public List<Product> GetProducts()
    {
        List<ProductDTO> productDTOs = database.Products.Include(productDto => productDto.Subcategory).ToList();

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
                    Name = productDTO.Subcategory.Name
                }
            };               

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
            .FirstOrDefault(p => p.ID == id);

        Product product = new()
        {
            ID = productDTO!.ID,
            Name = productDTO.Name,
            Brand = productDTO.Brand,
            CurrentStock = productDTO.CurrentStock,
            MinStock = productDTO.MinStock,
            MaxStock = productDTO.MaxStock,
            Subcategory = new Subcategory
            {
                ID = productDTO.Subcategory.ID,
                Name = productDTO.Subcategory.Name
            }
        };

        return product;
    }

    public void CreateProduct(string name, string brand, int subcategoryID,
        int currentStock, int minStock, int maxStock)
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
            
        database.Products.Add(productDTO);
        database.SaveChanges();
    }

    public void UpdateProduct(int id, string name, string brand,
        int currentStock, int minStock, int maxStock)
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
            
        ProductDTO productDTO = database.Products.FirstOrDefault(p => p.ID == id)!;
            
        productDTO.Name = name;
        productDTO.Brand = brand;
        productDTO.CurrentStock = currentStock;
        productDTO.MinStock = minStock;
        productDTO.MaxStock = maxStock;

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