
public class RegisterUseCase
{
    private readonly IAutentication _autentication;

    public RegisterUseCase(IAutentication autentication)
    {
        _autentication = autentication;
    }

    public void Register(string username, string password)
    {
        _autentication.Register(username, password);
    }
}
