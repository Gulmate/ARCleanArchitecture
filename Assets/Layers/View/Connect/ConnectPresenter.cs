using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;

public class ConnectPresenter : MonoBehaviour
{
    private ConnectUseCase _connectUseCase;

    [Inject]
    private readonly CustomNetworkManager manager;

    [Inject]
    void Awake()
    {
        _connectUseCase = new ConnectUseCase(manager);
    }

    public void Connect(string ip, string port)
    {
       manager.Connect(ip, port);
    }

    public void StartHost(string ip, string port)
    {
        manager.StartHostFromInput(ip, port);
    }

}
