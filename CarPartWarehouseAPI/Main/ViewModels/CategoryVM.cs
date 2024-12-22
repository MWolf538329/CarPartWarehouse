using Logic.Models;

namespace CarPartWarehouseAPI.ViewModels
{
    /// <summary>
    /// Represents a Category in the system
    /// </summary>
    public class CategoryVM(Category category)
    {
        /// <summary>
        /// Gets or sets the Category ID
        /// </summary>
        public int ID { get; set; } = category.ID;
        
        /// <summary>
        /// Gets or sets the Category Name
        /// </summary>
        public string Name { get; set; } = category.Name;
    }
}
