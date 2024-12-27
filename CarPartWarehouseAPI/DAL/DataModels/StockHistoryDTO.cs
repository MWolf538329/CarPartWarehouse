using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.DataModels
{
    public class StockHistoryDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        
        [ForeignKey(nameof(ProductID))]
        [Required]
        public int ProductID { get; set; }
        
        public DateTime StockChangeDate { get; set; }
        
        // [Required]
        // public int StockWas { get; set; }
        
        [Required]
        public int StockNow { get; set; }

        public virtual ProductDTO Product { get; set; }
    }
}
