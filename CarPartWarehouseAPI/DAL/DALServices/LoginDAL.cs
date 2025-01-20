using DAL.DataModels;
using Logic.Interfaces;
using Logic.Models;

namespace DAL.DALServices;

public class LoginDAL(DatabaseContext db) : ILoginDAL
{
    private DatabaseContext database { get; } = db;
    
    public bool Login(string username, string password)
    {
        bool valid = database.Credentials.Any(c => c.Username == username && c.Password == password);
        
        return valid;
    }

    public bool Register(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password)) return false;
            
        database.Credentials.Add(new CredentialDTO{ Username = username, Password = password});
        database.SaveChanges();
        return true;
    }

    public Session? GetSession(string sessionToken)
    {
        SessionDTO? sessionDTO = database.Sessions.FirstOrDefault(s => s.SessionToken == sessionToken);

        if (sessionDTO == null) return null;

        Session session = new()
        {
            ID = sessionDTO.ID,
            UserID = sessionDTO.UserID,
            ActivationDate = sessionDTO.ActivationDate,
            SessionToken = sessionDTO.SessionToken
        };

        return session;
    }

    public int GetUserIDByUsernameAndPassword(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password)) return 0;
        
        CredentialDTO? credential = database.Credentials.FirstOrDefault(c => c.Username == username && c.Password == password);
        
        return credential?.ID ?? 0;
    }

    public void StoreSessionToken(int userID, DateTime activationDate, string sessionToken)
    {
        if (userID == 0 || string.IsNullOrWhiteSpace(sessionToken)) return;
        
        database.Sessions.Add(new SessionDTO
        {
            UserID = userID,
            ActivationDate = activationDate,
            SessionToken = sessionToken
        });
        database.SaveChanges();
    }

    public void DeleteSession(int sessionID)
    {
        if (sessionID == 0 || !DoesSessionIDExist(sessionID)) return;
        
        database.Sessions.Remove(database.Sessions.FirstOrDefault(s => s.ID == sessionID)!);
        database.SaveChanges();
    }

    private bool DoesSessionIDExist(int sessionID)
    {
        return database.Sessions.Any(s => s.ID == sessionID);
    }
}