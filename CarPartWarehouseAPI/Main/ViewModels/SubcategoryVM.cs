using Logic.Models;
// ReSharper disable UnusedMember.Global

namespace CarPartWarehouseAPI.ViewModels;

/// <summary>
/// Represents a Subcategory in the system
/// </summary>
public class SubcategoryVM(Subcategory subcategory)
{
    /// <summary>
    /// Gets or sets the Subcategory ID
    /// </summary>
    public int ID { get; set; } = subcategory.ID;
        
    /// <summary>
    /// Gets or sets the Subcategory Name
    /// </summary>
    public string Name { get; set; } = subcategory.Name;
}