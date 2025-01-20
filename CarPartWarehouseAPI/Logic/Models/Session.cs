namespace Logic.Models;

public class Session
{
    public int ID { get; set; }
    public int UserID { get; set; }
    public DateTime ActivationDate { get; set; }
    public string SessionToken { get; set; } = string.Empty;
}