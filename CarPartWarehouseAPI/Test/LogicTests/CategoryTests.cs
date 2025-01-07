using Logic.Models;
using Logic.Services;
using Test.MockDALs;

namespace Test.LogicTests;

[TestClass]
public class CategoryTests
{
    private readonly CategoryMockDAL mockDAL;
    private readonly CategoryService categoryService;

    public CategoryTests()
    {
        mockDAL = new CategoryMockDAL();
        categoryService = new CategoryService(mockDAL);
    }

    [TestMethod]
    public void GetCategories()
    {
        // Act
        List<Category> result = categoryService.GetCategories();

        // Assert
        Assert.AreEqual(true, mockDAL.IsUsed);
        Assert.AreEqual(2, result.Count);
    }

    [TestMethod]
    [DataRow(1, "Motor")]
    [DataRow(2, "Transmissie")]
    public void GetCategory(int categoryID, string categoryName)
    {
        // Act
        Category result = categoryService.GetCategory(categoryID)!;

        // Assert
        Assert.AreEqual(true, mockDAL.IsUsed);
        Assert.AreEqual(categoryID, result.ID);
        Assert.AreEqual(categoryName, result.Name);
    }

    [TestMethod]
    [DataRow("Ophangssysteem")]
    public void CreateCategory(string name)
    {
        // Act
        categoryService.CreateCategory(name);

        // Assert
        Assert.AreEqual(true, mockDAL.IsUsed);
        Assert.AreEqual(true, mockDAL.IsCreated);
        Assert.AreEqual(3, mockDAL.Categories.Count);
        Assert.AreEqual(3, mockDAL.Categories[2].ID);
        Assert.AreEqual("Ophangssysteem", mockDAL.Categories[2].Name);
    }

    [TestMethod]
    [DataRow(1, "Updated")]
    public void UpdateCategory(int id, string name)
    {
        // Act
        categoryService.UpdateCategory(id, name);
            
        // Assert
        Assert.AreEqual(true, mockDAL.IsUsed);
        Assert.AreEqual(true, mockDAL.IsUpdated);
        Assert.AreEqual("Updated", mockDAL.Categories[id].Name);
    }

    [TestMethod]
    [DataRow(1)]
    public void DeleteCategory(int id)
    {
        // Act
        categoryService.DeleteCategory(id);
            
        // Assert
        Assert.AreEqual(true, mockDAL.IsUsed);
        Assert.AreEqual(true, mockDAL.IsDeleted);
        Assert.AreEqual(1, mockDAL.Categories.Count);
    }
}