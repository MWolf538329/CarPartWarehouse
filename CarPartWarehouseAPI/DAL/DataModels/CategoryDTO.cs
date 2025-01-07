using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// ReSharper disable ClassWithVirtualMembersNeverInherited.Global

namespace DAL.DataModels;

public class CategoryDTO
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; init; }
        
    [Required]
    [StringLength(255, ErrorMessage = "Name cannot be longer than 255 characters.")]
    public string Name { get; set; } = string.Empty;

    public virtual List<SubcategoryDTO> Subcategories { get; init; } = [];
}