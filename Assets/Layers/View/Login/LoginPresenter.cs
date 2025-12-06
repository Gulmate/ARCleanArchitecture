using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;

public class LoginPresenter : MonoBehaviour
{
    private LoginUseCase _loginUseCase;

    [Inject]
    private readonly IAutentication _autentication;

    [Inject]
    void Awake()
    {
        _loginUseCase = new LoginUseCase(_autentication);
    }

    public async void Login(string username, string password)
    {
        if(await _loginUseCase.Login(username, password))
        { SceneManager.LoadScene("Mirror"); }
        
    }

    public void Register(string username, string password, string firstName, string lastName, string role)
    {
        RegisterUseCase registerUseCase = new RegisterUseCase(_autentication);
        registerUseCase.Register(username, password, firstName, lastName, role);
    }

    public void SetOffline()
    {
        SceneManager.LoadScene("TutorialScene");
    }
}
