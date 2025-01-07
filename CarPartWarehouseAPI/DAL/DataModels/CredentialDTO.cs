using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// ReSharper disable PropertyCanBeMadeInitOnly.Global

namespace DAL.DataModels;

public class CredentialDTO
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    // ReSharper disable once UnusedMember.Global
    public int ID { get; init; }

    [Required]
    [MaxLength(255, ErrorMessage = "Username cannot be longer than 255 characters.")]
    public string Username { get; set; } = string.Empty;

    [Required]
    [MaxLength(255, ErrorMessage = "Password cannot be longer than 255 characters.")]
    public string Password { get; set; } = string.Empty;
}