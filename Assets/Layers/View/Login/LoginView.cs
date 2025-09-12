using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class LoginView : MonoBehaviour
{

    [SerializeField] private TMP_InputField userNameField;
    [SerializeField] private TMP_InputField passwordField;
    [SerializeField] private Button loginButton;

    [Inject]
    private readonly LoginPresenter _loginPresenter;

    void Start()
    {
        loginButton.onClick.AddListener(() =>
        {
            _loginPresenter.Login(userNameField.text, passwordField.text);
        }
        );
    }

}
