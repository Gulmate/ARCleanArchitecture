using UnityEngine;
using VContainer;

public class LoginPresenter : MonoBehaviour
{
    private ILoginUseCase _loginUseCase;

    [Inject]
    private readonly IAutentication _autentication;

    [Inject]
    void Awake()
    {
        _loginUseCase = new LoginUseCase(_autentication);
    }

    public void Login(string username, string password)
    {
        _loginUseCase.Login(username, password);
    }
}
