using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.DataModels;

public class CredentialDTO
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }

    [Required] 
    public string Username { get; set; } = string.Empty;

    [Required] 
    public string Password { get; set; } = string.Empty;
}