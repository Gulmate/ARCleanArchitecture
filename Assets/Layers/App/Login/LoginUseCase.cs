
public class LoginUseCase: ILoginUseCase
{
    private readonly IAutentication _autentication;

    public LoginUseCase(IAutentication autentication)
    {
        _autentication = autentication;
    }

    public void Login(string username, string password)
    {
        _autentication.Login(username, password);
    }

}
