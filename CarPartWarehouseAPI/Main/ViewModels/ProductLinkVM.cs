using Logic.Models;
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

namespace CarPartWarehouseAPI.ViewModels;

/// <summary>
/// Represents a ProductLink in the system
/// </summary>
public class ProductLinkVM(ProductLink productLink)
{
    /// <summary>
    /// Gets or sets the ProductLink ID
    /// </summary>
    public int ID { get; set; } = productLink.ID;
        
    /// <summary>
    /// Gets or sets the ProductLink URL
    /// </summary>
    public string Url { get; set; } = productLink.Url;
}