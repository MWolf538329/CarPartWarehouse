using Logic.Models;
using Logic.Services;
using Test.MockDALs;

namespace Test.LogicTests
{
    [TestClass]
    public class CategoryTests
    {
        private CategoryMockDAL mockDAL;
        private CategoryService categoryService;

        public CategoryTests()
        {
            mockDAL = new();
            categoryService = new(mockDAL);
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
            Category result = categoryService.GetCategory(categoryID);

            // Assert
            Assert.AreEqual(true, mockDAL.IsUsed);
            Assert.AreEqual(categoryID, result.ID);
            Assert.AreEqual(categoryName, result.Name);
        }

        [TestMethod]
        [DataRow("Ophangssysteem")]
        public void AddCategory(string name)
        {
            // Act
            categoryService.CreateCategory(name);

            // Assert
            Assert.AreEqual(true, mockDAL.IsUsed);
            Assert.AreEqual(true, mockDAL.IsAdded);
            Assert.AreEqual(3, mockDAL.Categories.Count);
            Assert.AreEqual(3, mockDAL.Categories[2].ID);
            Assert.AreEqual("Ophangssysteem", mockDAL.Categories[2].Name);
        }

        //[TestMethod]
        //public void EditCategory()
        //{

        //}
    }
}