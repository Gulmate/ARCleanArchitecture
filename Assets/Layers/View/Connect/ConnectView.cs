using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class ConnectView : MonoBehaviour
{
    [SerializeField] private TMP_InputField IPField;
    [SerializeField] private TMP_InputField PortField;
    [SerializeField] private Button connectButton;
    [SerializeField] private Button hostButton;

    [Inject]
    private readonly ConnectPresenter _connectPresenter;

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
    }
}
