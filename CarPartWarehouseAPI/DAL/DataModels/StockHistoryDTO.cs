using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// ReSharper disable ClassWithVirtualMembersNeverInherited.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

namespace DAL.DataModels;

public class StockHistoryDTO
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
        
    [ForeignKey(nameof(ProductID))]
    [Required]
    public int ProductID { get; set; }
        
    public DateTime StockChangeDate { get; set; }
        
    [Required]
    public int StockNow { get; set; }

    public virtual ProductDTO Product { get; set; }
}