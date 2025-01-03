using Logic.Models;
using Logic.Services;
using Test.MockDALs;

namespace Test.LogicTests
{
    [TestClass]
    public class ProductTests
    {
        private readonly CategoryMockDAL categoryMockDal;
        private readonly ProductMockDAL productMockDAL;
        
        private readonly ProductService productService;
        
        public ProductTests()
        {
            categoryMockDal = new CategoryMockDAL();
            productMockDAL = new ProductMockDAL();
            productService = new ProductService(productMockDAL, categoryMockDal);
        }

        [TestMethod]
        public void GetProducts()
        {
            // Act
            List<Product> result = productService.GetProducts();
            
            // Assert
            Assert.AreEqual(true, productMockDAL.IsUsed);
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        [DataRow("Remblokken", "Brembo", 1, 7, 3, 10)]
        public void CreateProduct(string name, string brand, int subcategoryID, int currentStock, int minStock, int maxStock)
        {
            // Act
            productService.CreateProduct(name, brand, subcategoryID, currentStock, minStock, maxStock);
            
            // Assert
            Assert.AreEqual(true, productMockDAL.IsUsed);
            Assert.AreEqual(true, productMockDAL.IsCreated);
            Assert.AreEqual(3, productMockDAL.Products.Count);
            Assert.AreEqual(name, productMockDAL.Products.LastOrDefault()!.Name);
            Assert.AreEqual(brand, productMockDAL.Products.LastOrDefault()!.Brand);
            Assert.AreEqual(currentStock, productMockDAL.Products.LastOrDefault()!.CurrentStock);
            Assert.AreEqual(minStock, productMockDAL.Products.LastOrDefault()!.MinStock);
            Assert.AreEqual(maxStock, productMockDAL.Products.LastOrDefault()!.MaxStock);
        }

        [TestMethod]
        [DataRow(1, "Updated", "Updated", 1, 2, 2, 2)]
        public void UpdateSubcategory(int productID, string name, string brand, int subcategoryID, int currentStock, int minStock, int maxStock)
        {
            // Act
            productService.UpdateProduct(productID, name, brand, currentStock, minStock, maxStock);
            
            // Assert
            Assert.AreEqual(true, productMockDAL.IsUsed);
            Assert.AreEqual(true, productMockDAL.IsUpdated);
            Assert.AreEqual(2, productMockDAL.Products.Count);
            Assert.AreEqual(name, productMockDAL.Products[productID].Name);
            Assert.AreEqual(brand, productMockDAL.Products[productID].Brand);
            Assert.AreEqual(currentStock, productMockDAL.Products[productID].CurrentStock);
            Assert.AreEqual(minStock, productMockDAL.Products[productID].MinStock);
            Assert.AreEqual(maxStock, productMockDAL.Products[productID].MaxStock);
        }

        [TestMethod]
        [DataRow(1)]
        public void DeleteProduct(int productID)
        {
            // Act
            productMockDAL.DeleteProduct(productID);
            
            // Assert
            Assert.AreEqual(true, productMockDAL.IsUsed);
            Assert.AreEqual(true, productMockDAL.IsDeleted);
            Assert.AreEqual(1, productMockDAL.Products.Count);
        }
    }
}