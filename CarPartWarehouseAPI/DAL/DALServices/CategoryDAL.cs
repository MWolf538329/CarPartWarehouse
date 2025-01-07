using Logic.Interfaces;
using Logic.Models;
using DAL.DataModels;
using Microsoft.EntityFrameworkCore;
// ReSharper disable ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
// ReSharper disable ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator

namespace DAL.DALServices;

public class CategoryDAL(DatabaseContext db) : ICategoryDAL
{
    private DatabaseContext database { get; } = db;

    #region Category
    public List<Category> GetCategories()
    {
        List<Category> categories = [];
        List<CategoryDTO> categoryDTOs = database.Categories.ToList();

        foreach (CategoryDTO categoryDTO in categoryDTOs)
        {
            Category category = new()
            {
                ID = categoryDTO.ID,
                Name = categoryDTO.Name
            };
                
            categories.Add(category);
        }

        return categories;
    }

    public Category? GetCategory(int id)
    {
        if (!DoesCategoryIDExist(id))
        {
            return null;
        }
            
        CategoryDTO categoryDTO = database.Categories.Include(categoryDto => categoryDto.Subcategories)
            .FirstOrDefault(c => c.ID == id)!;

        Category category = new()
        {
            ID = categoryDTO.ID,
            Name = categoryDTO.Name,
            Subcategories = []
        };

        // ReSharper disable once InvertIf
        if (categoryDTO.Subcategories.Count != 0)
        {
            foreach (SubcategoryDTO subcategoryDTO in categoryDTO.Subcategories)
            {
                Subcategory subcategory = new()
                {
                    ID = subcategoryDTO.ID,
                    Name = subcategoryDTO.Name
                };
                    
                category.Subcategories.Add(subcategory);
            }
        }

        return category;
    }

    public void CreateCategory(string name)
    {
        if (string.IsNullOrWhiteSpace(name) || DoesCategoryAlreadyExist(name)) return;
            
        database.Categories.Add(new CategoryDTO { Name = name });
        database.SaveChanges();
    }

    public void UpdateCategory(int id, string name)
    {
        if (id == 0 || !DoesCategoryIDExist(id))
        {
            return;
        }

        if (string.IsNullOrWhiteSpace(name) || DoesCategoryAlreadyExist(name))
        {
            return;
        }
            
        CategoryDTO categoryDto = database.Categories.FirstOrDefault(c => c.ID == id)!;
        categoryDto.Name = name;
        database.SaveChanges();
    }

    public void DeleteCategory(int id)
    {
        if (id == 0 || !DoesCategoryIDExist(id)) return;
            
        database.Categories.Remove(database.Categories.FirstOrDefault(c => c.ID == id)!);
        database.SaveChanges();
    }

    public bool DoesCategoryAlreadyExist(string name)
    {
        return database.Categories.Any(c => c.Name == name);
    }
    public bool DoesCategoryIDExist(int id)
    {
        return database.Categories.Any(c => c.ID == id);
    }
    #endregion

    #region Subcategory
    public List<Subcategory> GetSubcategories(int categoryID)
    {
        List<Subcategory> subcategories = [];
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        List<SubcategoryDTO> subcategoryDTOs = database.Subcategories.Where(sc => sc.Category.ID == categoryID).ToList();
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        foreach (SubcategoryDTO subcategoryDTO in subcategoryDTOs)
        {
            Subcategory subcategory = new()
            {
                ID = subcategoryDTO.ID,
                Name = subcategoryDTO.Name
            };
                
            subcategories.Add(subcategory);
        }
            
        return subcategories;
    }

    public Subcategory? GetSubcategory(int subcategoryID)
    {
        if (!DoesSubcategoryIDExist(subcategoryID))
        {
            return null;
        }
            
        SubcategoryDTO subcategoryDTO = database.Subcategories.Include(subcategoryDto => subcategoryDto.Products)
            .FirstOrDefault(sc => sc.ID == subcategoryID)!;

        Subcategory subcategory = new()
        {
            ID = subcategoryDTO.ID,
            Name = subcategoryDTO.Name,
            Products = []
        };

        if (subcategoryDTO.Products.Count == 0) return subcategory;
        
        foreach (ProductDTO productDTO in subcategoryDTO.Products)
        {
            Product product = new()
            {
                ID = productDTO.ID,
                Name = productDTO.Name,
                Brand = productDTO.Brand,
                CurrentStock = productDTO.CurrentStock,
                MinStock = productDTO.MinStock,
                MaxStock = productDTO.MaxStock
            };
                                
            subcategory.Products.Add(product);
        }

        return subcategory;
    }

    public void CreateSubcategory(int categoryID, string name)
    {
        if (categoryID == 0 || !DoesCategoryIDExist(categoryID))
        {
            return;
        }

        if (string.IsNullOrWhiteSpace(name) || DoesSubcategoryAlreadyExist(name))
        {
            return;
        }
            
        SubcategoryDTO newSubcategoryDTO = new() { Name = name, CategoryID = categoryID};
        database.Subcategories.Add(newSubcategoryDTO);
        database.SaveChanges();
    }

    public void UpdateSubcategory(int subcategoryID, string name)
    {
        if (subcategoryID == 0 || !DoesSubcategoryIDExist(subcategoryID))
        {
            return;
        }

        if (string.IsNullOrWhiteSpace(name) || DoesSubcategoryAlreadyExist(name))
        {
            return;
        }

        SubcategoryDTO subcategoryDto = database.Subcategories.FirstOrDefault(sc => sc.ID == subcategoryID)!;
        subcategoryDto.Name = name;
        database.SaveChanges();
    }

    public void DeleteSubcategory(int id)
    {
        if (id == 0 || !DoesSubcategoryIDExist(id))
        {
            return;
        }
            
        database.Subcategories.Remove(database.Subcategories.FirstOrDefault(sc => sc.ID == id)!);
        database.SaveChanges();
    }

    public bool DoesSubcategoryAlreadyExist(string name)
    {
        return database.Subcategories.Any(sc => sc.Name == name);
    }
    public bool DoesSubcategoryIDExist(int id)
    {
        return database.Subcategories.Any(sc => sc.ID == id);
    }
    #endregion

    #region Product
    public List<Category> GetCategoriesWithSubcategoriesWithProducts()
    {
        List<Category> categories = [];
        List<CategoryDTO> categoryDTOs = database.Categories.Include(categoryDto => categoryDto.Subcategories)
            .ThenInclude(subcategoryDto => subcategoryDto.Products).ToList();

        foreach (CategoryDTO categoryDTO in categoryDTOs)
        {
            Category category = new()
            {
                ID = categoryDTO.ID,
                Name = categoryDTO.Name,
                Subcategories = []
            };

            if (categoryDTO.Subcategories.Count != 0)
            {
                foreach (SubcategoryDTO subcategoryDTO in categoryDTO.Subcategories)
                {
                    Subcategory subcategory = new()
                    {
                        ID = subcategoryDTO.ID,
                        Name = subcategoryDTO.Name,
                        Products = []
                    };

                    if (subcategoryDTO.Products.Count != 0)
                    {
                        foreach (ProductDTO productDTO in subcategoryDTO.Products)
                        {
                            Product product = new()
                            {
                                ID = productDTO.ID,
                                Name = productDTO.Name,
                                Brand = productDTO.Brand,
                                CurrentStock = productDTO.CurrentStock,
                                MinStock = productDTO.MinStock,
                                MaxStock = productDTO.MaxStock
                            };
                                
                            subcategory.Products.Add(product);
                        }
                    }
                        
                    category.Subcategories.Add(subcategory);
                }
            }
                
            categories.Add(category);
        }

        return categories;
    }
    #endregion
}