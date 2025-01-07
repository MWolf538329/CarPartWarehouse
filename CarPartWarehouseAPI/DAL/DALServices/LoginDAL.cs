using DAL.DataModels;
using Logic.Interfaces;

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
}