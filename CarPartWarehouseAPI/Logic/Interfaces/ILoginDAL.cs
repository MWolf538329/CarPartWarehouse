using Logic.Models;

namespace Logic.Interfaces;

public interface ILoginDAL
{
    public bool Login(string username, string password);
    public bool Register(string username, string password);

    public Session? GetSession(string sessionToken);
    public int GetUserIDByUsernameAndPassword(string username, string password);
    public void StoreSessionToken(int userID, DateTime activationDate, string sessionToken);
    public void DeleteSession(int sessionID);
}