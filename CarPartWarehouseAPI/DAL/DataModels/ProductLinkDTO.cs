using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// ReSharper disable PropertyCanBeMadeInitOnly.Global

namespace DAL.DataModels;

public class ProductLinkDTO
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; init; }
        
    [ForeignKey(nameof(ProductID))]
    [Required]
    public int ProductID { get; init; }
        
    [MaxLength(255, ErrorMessage = "Url can not be longer than 255 characters")]
    public string Url { get; set; } = string.Empty;
}