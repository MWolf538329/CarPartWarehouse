using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.DataModels;

public class SessionDTO
{
    [Key]
    public int ID { get; init; }
    
    [ForeignKey(nameof(UserID))]
    public int UserID { get; init; }
    
    
    public DateTime ActivationDate { get; init; }

    [MaxLength(255)]
    public string SessionToken { get; init; } = string.Empty;
}