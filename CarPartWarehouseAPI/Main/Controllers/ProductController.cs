﻿using System.Data;
using CarPartWarehouseAPI.ViewModels;
using Logic.Interfaces;
using Logic.Models;
using Logic.Services;
using DAL.DALServices;
using DAL;
using Microsoft.AspNetCore.Mvc;

namespace CarPartWarehouseAPI.Controllers
{
    [Route("/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        /// <summary>
        /// Get Products
        /// </summary>
        /// <returns>A JSON array with Products</returns>
        /// <response code ="200">Success: The request was successful and the Product data is returned.</response>
        [HttpGet("/products")]
        public ActionResult<List<ProductVM>> GetProducts(DatabaseContext databaseContext)
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

            return productVMs;
        }

        /// <summary>
        /// Get Product
        /// </summary>
        /// <returns>A JSON array with Products</returns>
        /// <response code ="200">Success: The request was successful and the Product data is returned.</response>
        /// <response code ="400">Bad Request: The request was unsuccessful.</response>
        /// <response code ="404">Not Found: The request was unsuccessful because the Category ID does not exist.</response>
        [HttpGet("/products/{id}")]
        public ActionResult<ProductVM> GetProduct(DatabaseContext databaseContext, int id)
        {
            IProductDAL productDAL = new ProductDAL(databaseContext);
            ICategoryDAL categoryDAL = new CategoryDAL(databaseContext);
            ProductService productService = new(productDAL, categoryDAL);

            if (id == 0)
            {
                return BadRequest("Product ID can not be 0!");
            }

            if (!productService.DoesProductIDExist(id))
            {
                return NotFound("Product ID does not Exist!");
            }

            Product product = productService.GetProduct(id)!;
                
            ProductWithLinkVM productVM = new(product);
            return productVM;
        }

        /// <summary>
        /// Create Product
        /// </summary>
        /// <returns></returns>
        /// <response code ="200">Success: The request was successful and the Product data is returned.</response>
        /// <response code ="400">Bad Request: The request was unsuccessful.</response>
        /// <response code ="404">Not Found: The request was unsuccessful because the Category ID does not exist.</response>
        [HttpPost("/products")]
        public ActionResult CreateProduct(DatabaseContext databaseContext, string name, string brand,
            int subcategoryID, int currentStock, int minStock, int maxStock)
        {
            IProductDAL productDAL = new ProductDAL(databaseContext);
            ICategoryDAL categoryDAL = new CategoryDAL(databaseContext);
            ProductService productService = new(productDAL, categoryDAL);
            CategoryService categoryService = new(categoryDAL);

            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Product Name can not be empty!");
            }

            if (string.IsNullOrWhiteSpace(brand))
            {
                return BadRequest("Product Brand can not be empty!");
            }

            if (subcategoryID == 0)
            {
                return BadRequest("Subcategory can not be empty!");
            }

            if (!categoryService.DoesSubcategoryIDExist(subcategoryID))
            {
                return NotFound("Subcategory does not exist!");
            }

            if (currentStock < 0)
            {
                return BadRequest("Current Stock can not be lower than 0!");
            }

            if (minStock < 0)
            {
                return BadRequest("Min Stock can not be lower than 0!");
            }

            if (maxStock < 0)
            {
                return BadRequest("Max Stock can not be lower than 0!");
            }


            productService.CreateProduct(name, brand, subcategoryID, currentStock, minStock, maxStock);
            return Created();
        }
        
        /// <summary>
        /// Get Product
        /// </summary>
        /// <returns>A JSON array with Products</returns>
        /// <response code ="200">Success: The request was successful and the Product data is returned.</response>
        /// <response code ="400">Bad Request: The request was unsuccessful.</response>
        /// <response code ="404">Not Found: The request was unsuccessful because the Category ID does not exist.</response>
        [HttpPost("/products")]
        public ActionResult CreateProduct(DatabaseContext databaseContext, int id, string name, string brand,
            int subcategoryID, int currentStock, int minStock, int maxStock)
        {
            IProductDAL productDAL = new ProductDAL(databaseContext);
            ICategoryDAL categoryDAL = new CategoryDAL(databaseContext);
            ProductService productService = new(productDAL, categoryDAL);
            CategoryService categoryService = new(categoryDAL);

            if (id == 0)
            {
                return BadRequest("ID can not be 0!");
            }

            if (!productService.DoesProductIDExist(id))
            {
                return NotFound("Product ID does not Exist!");
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Product Name can not be empty!");
            }

            if (string.IsNullOrWhiteSpace(brand))
            {
                return BadRequest("Product Brand can not be empty!");
            }

            if (subcategoryID == 0)
            {
                return BadRequest("Subcategory can not be empty!");
            }

            if (!categoryService.DoesSubcategoryIDExist(subcategoryID))
            {
                return NotFound("Subcategory does not exist!");
            }

            if (currentStock < 0)
            {
                return BadRequest("Current Stock can not be lower than 0!");
            }

            if (minStock < 0)
            {
                return BadRequest("Min Stock can not be lower than 0!");
            }

            if (maxStock < 0)
            {
                return BadRequest("Max Stock can not be lower than 0!");
            }


            productService.UpdateProduct(id, name, brand, subcategoryID, currentStock, minStock, maxStock);
            return Created();
        }

        /// <summary>
        /// Delete Product
        /// </summary>
        /// <returns></returns>
        [HttpDelete("/products/{id}")]
        public ActionResult DeleteProduct(DatabaseContext databaseContext, int id)
        {
            IProductDAL productDAL = new ProductDAL(databaseContext);
            ICategoryDAL categoryDAL = new CategoryDAL(databaseContext);
            ProductService productService = new(productDAL, categoryDAL);

            if (id == 0)
            {
                return BadRequest("ID can not be 0!");
            }

            if (!productService.DoesProductIDExist(id))
            {
                return NotFound("Product ID does not Exist!");
            }

            productService.DeleteProduct(id);
            return Ok("Product Successfully Deleted!");
        }
    }
}
