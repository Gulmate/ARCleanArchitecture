
using System.Threading.Tasks;

public class LoginUseCase
{
    private readonly IAutentication _autentication;

    public LoginUseCase(IAutentication autentication)
    {
        _autentication = autentication;
    }

    public Task<bool> Login(string username, string password)
    {
       return  _autentication.Login(username, password);
    }

}
