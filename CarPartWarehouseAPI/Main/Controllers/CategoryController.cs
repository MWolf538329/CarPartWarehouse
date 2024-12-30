using CarPartWarehouseAPI.ViewModels;
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

            if (id == 0)
            {
                return BadRequest("Category ID can not be 0!");
            }

            if (!categoryService.DoesCategoryIDExist(id))
            {
                return NotFound("Category ID does not exist!");
            }

            Category category = categoryService.GetCategory(id)!;

            CategoryWithSubcategoryVM categoryVM = new(category);

            return categoryVM;
        }

        /// <summary>
        /// Create Category
        /// </summary>
        /// <param name="name">Category Name</param>
        /// <returns>HTTP response code</returns>
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

            if (categoryService.DoesCategoryAlreadyExist(name))
            {
                return BadRequest("Category already exists!");
            }

            categoryService.CreateCategory(name);
            return Created();
        }

        /// <summary>
        /// Update Category
        /// </summary>
        /// <param name="id">Category ID</param>
        /// <param name="name">Name</param>
        /// <returns>HTTP response code</returns>
        /// <response code="201">Updated: Category was successfully Updated.</response>
        /// <response code="400">Bad Request: Category Name can not be empty.</response>
        [HttpPut("/categories/{id}")]
        public ActionResult UpdateCategory(DatabaseContext databaseContext, int id, string name)
        {
            ICategoryDAL categoryDAL = new CategoryDAL(databaseContext);
            CategoryService categoryService = new(categoryDAL);

            if (id == 0)
            {
                return BadRequest("Category ID can not be 0!");
            }

            if (!categoryService.DoesCategoryIDExist(id))
            {
                return NotFound("Category ID does not exist!");
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Name can not be empty!");
            }

            if (categoryService.DoesCategoryAlreadyExist(name))
            {
                return BadRequest("Category already exists!");
            }

            categoryService.UpdateCategory(id, name);
            return Created();
        }
        
        /// <summary>
        /// Delete Category
        /// </summary>
        /// <param name="id">Category ID</param>
        /// <returns></returns>
        /// <response code="200">Deleted: Category was successfully Deleted.</response>
        /// <response code="400">Bad Request: Category ID can not be 0.</response>
        /// <response code="404">Not Found: Category ID does not exist.</response>
        [HttpDelete("/categories/{id}")]
        public ActionResult DeleteCategory(DatabaseContext databaseContext, int id)
        {
            ICategoryDAL categoryDAL = new CategoryDAL(databaseContext);
            CategoryService categoryService = new(categoryDAL);

            if (id == 0)
            {
                return BadRequest("Category ID can not be 0!");
            }

            if (!categoryService.DoesCategoryIDExist(id))
            {
                return NotFound("Category ID does not exist!");
            }

            categoryService.DeleteCategory(id);
            return Ok("Category successfully Deleted!");
        }
        #endregion
        
        #region Subcategory
        /// <summary>
        /// Get Subcategories
        /// </summary>
        /// <param name="categoryId">Category ID</param>
        /// <returns></returns>
        [HttpGet("/categories/{categoryId}/subcategories")]
        public ActionResult<List<SubcategoryVM>> GetSubcategories(DatabaseContext databaseContext, int categoryId)
        {
            ICategoryDAL categoryDAL = new CategoryDAL(databaseContext);
            CategoryService categoryService = new(categoryDAL);

            List<SubcategoryVM> subcategoryVMs = [];

            foreach (Subcategory subcategory in categoryService.GetSubcategories(categoryId))
            {
                SubcategoryVM subcategoryVM = new(subcategory);

                subcategoryVMs.Add(subcategoryVM);
            }

            return subcategoryVMs;
        }

        /// <summary>
        /// Get a Subcategory
        /// </summary>
        /// <param name="categoryId">Category ID</param>
        /// <param name="subcategoryId">Subcategory ID</param>
        /// <returns></returns>
        /// <response code="200"></response>
        [HttpGet("/categories/{categoryId}/subcategories/{subcategoryId}")]
        public ActionResult<SubcategoryWithProductVM> GetSubcategory(DatabaseContext databaseContext, int categoryId, int subcategoryId)
        {
            ICategoryDAL categoryDAL = new CategoryDAL(databaseContext);
            CategoryService categoryService = new(categoryDAL);

            if (categoryId == 0)
            {
                return BadRequest("Category ID can not be 0!");
            }

            if (!categoryService.DoesCategoryIDExist(categoryId))
            {
                return NotFound("Category ID does not exist!");
            }
            
            if (subcategoryId == 0)
            {
                return BadRequest("Subcategory ID can not be 0!");
            }

            if (!categoryService.DoesSubcategoryIDExist(subcategoryId))
            {
                return NotFound("Subcategory ID does not exist!");
            }
            
            Subcategory subcategory = categoryService.GetSubcategory(subcategoryId)!;

            SubcategoryWithProductVM subcategoryVM = new(subcategory);
            
            return subcategoryVM;
        }
        
        /// <summary>
        /// Create Subcategory
        /// </summary>
        /// <param name="categoryId">Category ID</param>
        /// <param name="name">Subcategory Name</param>
        /// <returns></returns>
        /// <response code="200"></response>
        [HttpPost("/categories/{categoryId}/subcategories")]
        public ActionResult CreateSubcategory(DatabaseContext databaseContext, int categoryId, string name)
        {
            ICategoryDAL categoryDAL = new CategoryDAL(databaseContext);
            CategoryService categoryService = new(categoryDAL);

            if (categoryId == 0)
            {
                return BadRequest("Category ID can not be 0!");
            }

            if (!categoryService.DoesCategoryIDExist(categoryId))
            {
                return NotFound("Category ID does not exist!");
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Name can not be empty!");
            }

            if (categoryService.DoesSubcategoryAlreadyExist(name))
            {
                return BadRequest("Subcategory already exists!");
            }
        
            categoryService.CreateSubcategory(categoryId, name);
            return Created();
        }

        /// <summary>
        /// Update Subcategory
        /// </summary>
        /// <param name="categoryId">Category ID</param>
        /// <param name="subcategoryId">Subcategory ID</param>
        /// <param name="name">Subcategory Name</param>
        /// <returns></returns>
        [HttpPut("/categories/{categoryId}/subcategories/{subcategoryId}")]
        public ActionResult UpdateSubcategory(DatabaseContext databaseContext, int categoryId, int subcategoryId, string name)
        {
            ICategoryDAL categoryDAL = new CategoryDAL(databaseContext);
            CategoryService categoryService = new(categoryDAL);

            if (subcategoryId == 0)
            {
                return BadRequest("Subcategory ID can not be 0!");
            }

            if (!categoryService.DoesSubcategoryIDExist(subcategoryId))
            {
                return NotFound("Subcategory ID does not exist!");
            }

            if (categoryId == 0)
            {
                return BadRequest("category ID can not be 0!");
            }

            if (!categoryService.DoesCategoryIDExist(categoryId))
            {
                return NotFound("Category ID does not exist!");
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Name can not be empty!");
            }

            if (categoryService.DoesSubcategoryAlreadyExist(name))
            {
                return BadRequest("Subcategory already exists!");
            }

            categoryService.UpdateSubcategory(subcategoryId, name);
            return Created();
        }

        /// <summary>
        /// Delete Subcategory
        /// </summary>
        /// <param name="categoryId">Category ID</param>
        /// <param name="subcategoryId">Subcategory ID</param>
        /// <returns></returns>
        [HttpDelete("/categories/{categoryId}/subcategories/{subcategoryId}")]
        public ActionResult DeleteSubcategory(DatabaseContext databaseContext, int categoryId, int subcategoryId)
        {
            ICategoryDAL categoryDAL = new CategoryDAL(databaseContext);
            CategoryService categoryService = new(categoryDAL);

            if (subcategoryId == 0)
            {
                return BadRequest("Subcategory ID can not be 0!");
            }

            if (!categoryService.DoesSubcategoryIDExist(subcategoryId))
            {
                return BadRequest("Subcategory ID does not exist!");
            }

            categoryService.DeleteSubcategory(subcategoryId);
            return Ok("Subcategory successfully Deleted!");
        }
        #endregion
        
        #region Product
        /// <summary>
        /// Get Categories with Subcategories with Products
        /// </summary>
        /// <returns></returns>
        [HttpGet("/categories/subcategories/products")]
        public ActionResult<List<CategoryWithSubcategoryVM>> GetProducts(DatabaseContext databaseContext)
        {
            ICategoryDAL categoryDAL = new CategoryDAL(databaseContext);
            CategoryService categoryService = new(categoryDAL);

            List<CategoryWithSubcategoryVM> categoryVMs = [];

            foreach (Category category in categoryService.GetCategoriesWithSubcategoriesWithProducts())
            {
                CategoryWithSubcategoryVM categoryVM = new(category);

                categoryVMs.Add(categoryVM);
            }

            return categoryVMs;
        }
        #endregion
    }
}
