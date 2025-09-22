using VContainer;

public class AuthenticationService : IAutentication
{
    [Inject]
    private readonly IFileHandlerService _logger;
    public void Login(string username, string password)
    {
        DummyLoginCheck(username, password);
    }

    public void Register(string username, string password)
    {
        throw new System.NotImplementedException();
    }

    private void DummyLoginCheck(string username, string password)
    {
        if (username != "Admin" || password != "admin")
        {
            _logger.SaveLog("Login Attempt failed: Wrong username or password");
        }
        else
        {
            _logger.SaveLog("Login Attempt failed: Error 500 Internal server error");
        }
    }
}
