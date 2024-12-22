using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.DataModels
{
    public class ProductDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        
        [Required]
        [StringLength(255, ErrorMessage = "Name cannot be longer than 255 characters.")]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [StringLength(255, ErrorMessage = "Brand cannot be longer than 255 characters.")]
        public string Brand { get; set; } = string.Empty;
        
        [Required]
        public int CurrentStock { get; set; }
        
        [Required]
        public int MinStock { get; set; }
        
        [Required]
        public int MaxStock { get; set; }

        public virtual SubcategoryDTO Subcategory { get; set; }
        public virtual List<ProductLinkDTO> Links { get; set; } = [];
    }
}
