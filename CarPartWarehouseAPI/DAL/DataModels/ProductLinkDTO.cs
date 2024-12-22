using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.DataModels
{
    public class ProductLinkDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        
        [ForeignKey(nameof(ProductID))]
        [Required]
        public int ProductID { get; set; }
        
        public string Url { get; set; } = string.Empty;
    }
}
