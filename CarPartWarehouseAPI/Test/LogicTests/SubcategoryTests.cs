using Logic.Models;
using Logic.Services;
using Test.MockDALs;

namespace Test.LogicTests;

[TestClass]
public class SubcategoryTests
{
    private readonly CategoryMockDAL mockDAL;
    private readonly CategoryService categoryService;
        
    public SubcategoryTests()
    {
        mockDAL = new CategoryMockDAL();
        categoryService = new CategoryService(mockDAL);
    }

    [TestMethod]
    [DataRow(1, "Motor", 1)]
    [DataRow(2, "Transmissie", 2)]
    public void GetSubcategories(int categoryID, string name, int aantal)
    {
        // Act
        List<Subcategory> result = categoryService.GetSubcategories(categoryID);
            
        // Assert
        Assert.AreEqual(true, mockDAL.IsUsed);
        Assert.AreEqual(name, result.FirstOrDefault()!.Category.Name);
        Assert.AreEqual(aantal, result.Count);
    }

    [TestMethod]
    [DataRow(1, "Cilinders")]
    [DataRow(2, "Handgeschakelde Transmissie")]
    [DataRow(3, "Automatische Transmissie")]
    public void GetSubcategory(int subcategoryID, string name)
    {
        // Act
        Subcategory result = mockDAL.GetSubcategory(subcategoryID)!;

        // Assert
        Assert.AreEqual(true, mockDAL.IsUsed);
        Assert.AreEqual(subcategoryID, result.ID);
        Assert.AreEqual(name, result.Name);
    }

    [TestMethod]
    [DataRow(2, "Koppeling")]
    public void CreateSubcategory(int categoryID, string name)
    {
        // Act
        mockDAL.CreateSubcategory(categoryID, name);
            
        // Assert
        Assert.AreEqual(true, mockDAL.IsUsed);
        Assert.AreEqual(true, mockDAL.IsCreated);
        Assert.AreEqual(4, mockDAL.Subcategories.Count);
        Assert.AreEqual(name, mockDAL.Subcategories.LastOrDefault()!.Name);
    }

    [TestMethod]
    [DataRow(1, "Updated")]
    public void UpdateSubcategory(int subcategoryID, string name)
    {
        // Act
        mockDAL.UpdateSubcategory(subcategoryID, name);
            
        // Assert
        Assert.AreEqual(true, mockDAL.IsUsed);
        Assert.AreEqual(true, mockDAL.IsUpdated);
        Assert.AreEqual("Updated", mockDAL.Subcategories[subcategoryID].Name);
    }

    [TestMethod]
    [DataRow(1)]
    public void DeleteSubcategory(int subcategoryID)
    {
        // Act
        mockDAL.DeleteSubcategory(subcategoryID);
            
        // Assert
        Assert.AreEqual(true, mockDAL.IsUsed);
        Assert.AreEqual(true, mockDAL.IsDeleted);
        Assert.AreEqual(2, mockDAL.Subcategories.Count);
    }
}