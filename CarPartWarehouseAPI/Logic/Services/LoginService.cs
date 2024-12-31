using Logic.Interfaces;

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
}