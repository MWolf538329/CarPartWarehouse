using Logic.Interfaces;
using Logic.Models;

namespace Logic.Services;

public class LoginService(ILoginDAL loginDal)
{
    public bool Login(string username, string password)
    {
        bool valid = loginDal.Login(username, password);

        return valid;
    }

    public bool Register(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            return false;
        }
        
        return loginDal.Register(username, password);
    }
    
    public int GetUserIDByUsernameAndPassword(string username, string password)
    {
        return loginDal.GetUserIDByUsernameAndPassword(username, password);
    }
    
    public string GenerateAndStoreToken(int userID)
    {
        string sessionToken = GenerateSessionToken();
        StoreSessionToken(userID, sessionToken);
        
        return sessionToken;
    }
    
    public bool IsSessionValid(string sessionToken)
    {
        Session? session = loginDal.GetSession(sessionToken);

        if (session == null) return false;
        
        if (session.ActivationDate.AddMinutes(15) < DateTime.Now)
        {
            loginDal.DeleteSession(session.ID);
            return false;
        }
        
        return true;
    }
    
    
    
    private static string GenerateSessionToken()
    {
        return Guid.NewGuid().ToString();
    }

    private void StoreSessionToken(int userID, string sessionToken)
    {
        loginDal.StoreSessionToken(userID, DateTime.Now, sessionToken);
    }
}