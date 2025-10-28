using UnityEngine.SceneManagement;
using VContainer;

public class AuthenticationService : IAutentication
{
    [Inject]
    private readonly IFileHandlerService _logger;
    public bool Login(string username, string password)
    {
        return DummyLoginCheck(username, password);
    }

    public void Register(string username, string password)
    {
        DummyRegisterCheck(username, password);
    }

    private bool DummyLoginCheck(string username, string password)
    {
        if (username != "Admin" || password != "admin")
        {
            _logger.SaveLog("Login Attempt failed: Wrong username or password");
            return false;
        }
        else
        {
            _logger.SaveLog("Successful login");
            return true;
        }
    }

    private void DummyRegisterCheck(string username, string password)
    {
        _logger.SaveLog("Register Attempt failed: Error 500 Internal server error");
    }   
}
