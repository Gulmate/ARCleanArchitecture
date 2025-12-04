using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class LoginView : MonoBehaviour
{
    [SerializeField] private GameObject loginPanel;
    [SerializeField] private TMP_InputField userNameField;
    [SerializeField] private TMP_InputField passwordField;
    [SerializeField] private Button loginButton;
    [SerializeField] private Button registerButton;

    [SerializeField] private GameObject onlineOfflinePanel;
    [SerializeField] private Button onlineButton;
    [SerializeField] private Button offlineButton;

    [Inject]
    private readonly LoginPresenter _loginPresenter;

    void Start()
    {
        loginButton.onClick.AddListener(() =>
        {
            _loginPresenter.Login(userNameField.text, passwordField.text);
        });
        registerButton.onClick.AddListener(() =>
        {
            _loginPresenter.Register(userNameField.text, passwordField.text);
        });

        onlineButton.onClick.AddListener(() =>
        {
            loginPanel.SetActive(true);
            onlineOfflinePanel.SetActive(false);
        });

        offlineButton.onClick.AddListener(() =>
        {
            _loginPresenter.SetOffline();
        });

        loginPanel.SetActive(false);
    }

}
