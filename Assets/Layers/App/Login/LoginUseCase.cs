
public class LoginUseCase
{
    private readonly IAutentication _autentication;

    public LoginUseCase(IAutentication autentication)
    {
        _autentication = autentication;
    }

    public bool Login(string username, string password)
    {
       return  _autentication.Login(username, password);
    }

}
