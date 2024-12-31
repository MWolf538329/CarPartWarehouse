namespace Logic.Interfaces;

public interface ILoginDAL
{
    public bool Login(string username, string password);
    public bool Register(string username, string password);
}