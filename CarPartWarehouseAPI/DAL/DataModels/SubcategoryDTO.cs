using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.DataModels
{
    public class SubcategoryDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; init; }
        
        [ForeignKey(nameof(CategoryID))]
        [Required]
        public int CategoryID { get; set; }
        
        [Required]
        [StringLength(255, ErrorMessage = "Brand cannot be longer than 255 characters.")]
        public string Name { get; set; } = string.Empty;

        public virtual CategoryDTO Category { get; set; }
        public virtual List<ProductDTO> Products { get; init; } = [];
    }
}
