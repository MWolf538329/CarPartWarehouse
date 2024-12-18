﻿using CarPartWarehouseAPI.ViewModels;
using Logic.Interfaces;
using Logic.Models;
using Logic.Services;
using DAL.DALServices;
using DAL;
using Microsoft.AspNetCore.Mvc;

namespace CarPartWarehouseAPI.Controllers
{
    [Route("/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        #region Category
        /// <summary>
        /// Get Categories
        /// </summary>
        /// <returns>A JSON array containing Category Objects. Each Category has the following properties: id, name</returns>
        /// <response code="200">Success: The request was successful and the Category data is returned.</response>
        [HttpGet("/categories")]
        public ActionResult<List<CategoryVM>> GetCategories(DatabaseContext databaseContext)
        {
            ICategoryDAL categoryDAL = new CategoryDAL(databaseContext);
            CategoryService categoryService = new(categoryDAL);

            List<CategoryVM> categoryVMs = [];

            foreach (Category category in categoryService.GetCategories())
            {
                CategoryVM categoryVM = new(category);

                categoryVMs.Add(categoryVM);
            }

            return categoryVMs;
        }

        /// <summary>
        /// Get Category
        /// </summary>
        /// <param name="id">Category ID</param>
        /// /// <returns>A JSON string containing 1 Category Object with id and name.</returns>
        /// <response code="200">Success: The request was successful and the Category data is returned.</response>
        /// <response code="400">Bad Request: The request was unsuccessful.</response>
        /// <response code="404">Not Found: The request was unsuccessful because the Category ID does not exist.</response>
        [HttpGet("/categories/{id}")]
        public ActionResult<CategoryVM> GetCategory(DatabaseContext databaseContext, int id)
        {
            ICategoryDAL categoryDAL = new CategoryDAL(databaseContext);
            CategoryService categoryService = new(categoryDAL);

            if (id == 0) return BadRequest("Category ID can not be 0!");
            if (!categoryService.DoesCategoryIDExist(id)) return NotFound("Category ID does not exist!");

            Category category = categoryService.GetCategory(id)!;

            CategoryWithSubcategoryVM categoryVM = new(category);

            return categoryVM;
        }

        /// <summary>
        /// Create Category
        /// </summary>
        /// <param name="name">Category Name</param>
        /// <returns></returns>
        /// <response code="201">Created: Category was successfully Created.</response>
        /// <response code="400">Bad Request: Category Name can not be empty.</response>
        [HttpPost("/categories")]
        public ActionResult CreateCategory(DatabaseContext databaseContext, string name)
        {
            ICategoryDAL categoryDAL = new CategoryDAL(databaseContext);
            CategoryService categoryService = new(categoryDAL);

            if (string.IsNullOrWhiteSpace(name)) 
            {
                return BadRequest("Name can not be empty!");
            }
            if (categoryService.DoesCategoryAlreadyExist(name)) return BadRequest("Category already exists!");

            categoryService.CreateCategory(name);
            return Created();
        }
        
        /// <summary>
        /// Update Category
        /// </summary>
        /// <param name="id">Category ID</param>
        /// <param name="name">Category Name</param>
        /// <returns></returns>
        [HttpPut("/categories/{id}")]
        public ActionResult UpdateCategory(DatabaseContext databaseContext, int id, [FromBody] string name)
        {
            ICategoryDAL categoryDAL = new CategoryDAL(databaseContext);
            CategoryService categoryService = new(categoryDAL);

            if (id == 0) return BadRequest("Category ID can not be 0!");
            if (!categoryService.DoesCategoryIDExist(id)) return NotFound("Category ID does not exist!");

            if (string.IsNullOrWhiteSpace(name)) return BadRequest("Name can not be empty!");
            if (categoryService.DoesCategoryAlreadyExist(name)) return BadRequest("Category already exists!");

            categoryService.UpdateCategory(id, name);
            return Created();
        }
        
        /// <summary>
        /// Delete Category
        /// </summary>
        /// <param name="id">Category ID</param>
        /// <returns></returns>
        [HttpDelete("/categories/{id}")]
        public ActionResult DeleteCategory(DatabaseContext databaseContext, int id)
        {
            ICategoryDAL categoryDAL = new CategoryDAL(databaseContext);
            CategoryService categoryService = new(categoryDAL);

            if (id == 0) return BadRequest("Category ID can not be 0!");
            if (!categoryService.DoesCategoryIDExist(id)) return NotFound("Category ID does not exist!");

            categoryService.DeleteCategory(id);
            return Ok("Category successfully Deleted!");
        }
        #endregion
        
        #region Subcategory
        /// <summary>
        /// Get Subcategories
        /// </summary>
        /// <returns></returns>
        [HttpGet("/subcategories")]
        public ActionResult<List<SubcategoryVM>> GetSubcategories(DatabaseContext databaseContext)
        {
            ICategoryDAL categoryDAL = new CategoryDAL(databaseContext);
            CategoryService categoryService = new(categoryDAL);

            List<SubcategoryVM> subcategoryVMs = [];

            foreach (Subcategory subcategory in categoryService.GetSubcategories())
            {
                SubcategoryVM subcategoryVM = new(subcategory);

                subcategoryVMs.Add(subcategoryVM);
            }

            return subcategoryVMs;
        }

        // /// <summary>
        // /// Get Subcategories
        // /// </summary>
        // /// <param name="id"></param>
        // /// <returns></returns>
        // [HttpGet("/{id}/subcategories")]
        // public ActionResult GetSubcategories(DatabaseContext databaseContext, int id)
        // {
        //     
        // }

        // /// <summary>
        // /// Create Subcategory
        // /// </summary>
        // /// <param name="id"></param>
        // /// <param name="name"></param>
        // /// <returns></returns>
        // [HttpPost("/{id}/subcategories")]
        // public ActionResult CreateSubcategory(DatabaseContext databaseContext, int id, [FromBody] string name)
        // {
        //     ICategoryDAL categoryDAL = new CategoryDAL(databaseContext);
        //     CategoryService categoryService = new(categoryDAL);
        //
        //     if (categoryID == 0) return BadRequest("Category ID can not be 0!");
        //     if (!categoryService.DoesCategoryIDExist(categoryID)) return NotFound("Category ID does not exist!");
        //
        //     if (string.IsNullOrWhiteSpace(name)) return BadRequest("Name can not be empty!");
        //     if (categoryService.DoesSubcategoryAlreadyExist(name)) return BadRequest("Subcategory already exists!");
        //
        //     categoryService.CreateSubcategory(categoryID, name);
        //     return Created();
        // }

        /// <summary>
        /// Update Subcategory
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="subcategoryId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPut("/{categoryId}/subcategories/{subcategoryId}")]
        public ActionResult UpdateSubcategory(DatabaseContext databaseContext, int categoryId, int subcategoryId, [FromBody] string name)
        {
            ICategoryDAL categoryDAL = new CategoryDAL(databaseContext);
            CategoryService categoryService = new(categoryDAL);

            if (subcategoryId == 0) return BadRequest("Subcategory ID can not be 0!");
            if (!categoryService.DoesSubcategoryIDExist(subcategoryId)) return NotFound("Subcategory ID does not exist!");

            if (categoryId == 0) return BadRequest("category ID can not be 0!");
            if (!categoryService.DoesCategoryIDExist(categoryId)) return NotFound("Category ID does not exist!");

            if (string.IsNullOrWhiteSpace(name)) return BadRequest("Name can not be empty!");
            if (categoryService.DoesSubcategoryAlreadyExist(name)) return BadRequest("Subcategory already exists!");

            categoryService.UpdateSubcategory(subcategoryId, categoryId, name);
            return Created();
        }

        /// <summary>
        /// Delete Subcategory
        /// </summary>
        /// <param name="categoryId">Category ID</param>
        /// <param name="subcategoryId">Subcategory ID</param>
        /// <returns></returns>
        [HttpDelete("/{categoryId}/subcategories/{subcategoryId}")]
        public ActionResult DeleteSubcategory(DatabaseContext databaseContext, int categoryId, int subcategoryId)
        {
            ICategoryDAL categoryDAL = new CategoryDAL(databaseContext);
            CategoryService categoryService = new(categoryDAL);

            if (subcategoryId == 0) return BadRequest("Subcategory ID can not be 0!");
            if (!categoryService.DoesSubcategoryIDExist(subcategoryId))
                return BadRequest("Subcategory ID does not exist!");

            categoryService.DeleteSubcategory(subcategoryId);
            return Ok("Subcategory successfully Deleted!");
        }
        #endregion
        
        
        #region Product
        /// <summary>
        /// Get Categories with Subcategories with Products
        /// </summary>
        /// <returns></returns>
        [HttpGet("/subcategories/products")]
        public ActionResult<List<CategoryWithSubcategoryVM>> GetProducts(DatabaseContext databaseContext)
        {
            ICategoryDAL categoryDAL = new CategoryDAL(databaseContext);
            CategoryService categoryService = new(categoryDAL);

            List<CategoryWithSubcategoryVM> categoryVMs = [];

            foreach (Category category in categoryService.GetCategories())
            {
                CategoryWithSubcategoryVM categoryVM = new(category);

                categoryVMs.Add(categoryVM);
            }

            return categoryVMs;
        }
        #endregion
    }
}
