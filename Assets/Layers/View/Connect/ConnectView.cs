using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class ConnectView : MonoBehaviour
{
    [SerializeField] private TMP_InputField IPField;
    [SerializeField] private TMP_InputField PortField;
    [SerializeField] private GameObject onlinePanel;
    [SerializeField] private Button connectButton;
    [SerializeField] private Button hostButton;

    [SerializeField] private GameObject changePanel;
    [SerializeField] private Button onlineButton;
    [SerializeField] private Button offlineButton;

    [Inject]
    private readonly ConnectPresenter _connectPresenter;

    private CustomNetworkManager _networkManager;

    [Inject]
    private readonly IObjectResolver _resolver;

    void Start()
    {
        connectButton.onClick.AddListener(() =>
        {
            _connectPresenter.Connect(IPField.text, PortField.text);
        });
        hostButton.onClick.AddListener(() =>
        {
            _connectPresenter.StartHost(IPField.text, PortField.text);
        });
        onlineButton.onClick.AddListener(() =>
        {
            changePanel.SetActive(false);
            onlinePanel.SetActive(true);
            _networkManager = _resolver.Resolve<CustomNetworkManager>();
            _connectPresenter.SetToOnline(_networkManager);
        });
        offlineButton.onClick.AddListener(() =>
        {
            _connectPresenter.ChangeToOfflineScene();
        });
    }
}
