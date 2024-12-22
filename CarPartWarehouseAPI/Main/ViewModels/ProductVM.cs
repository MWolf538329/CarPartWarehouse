using Logic.Models;

namespace CarPartWarehouseAPI.ViewModels
{
    /// <summary>
    /// Represents a Product in the system
    /// </summary>
    public class ProductVM(Product product)
    {
        /// <summary>
        /// Gets or sets the Product ID
        /// </summary>
        public int ID { get; set; } = product.ID;
        
        /// <summary>
        /// Gets or sets the Product Name
        /// </summary>
        public string Name { get; set; } = product.Name;
        
        /// <summary>
        /// Gets or sets the Product Brand
        /// </summary>
        public string Brand { get; set; } = product.Brand;
        
        /// <summary>
        /// Gets or sets the Product CurrentStock
        /// </summary>
        public int CurrentStock { get; set; } = product.CurrentStock;
        
        /// <summary>
        /// Gets or sets the Product MinStock
        /// </summary>
        public int MinStock { get; set; } = product.MinStock;
        
        /// <summary>
        /// Gets or sets the Product MaxStock
        /// </summary>
        public int MaxStock { get; set; } = product.MaxStock;
    }
}
