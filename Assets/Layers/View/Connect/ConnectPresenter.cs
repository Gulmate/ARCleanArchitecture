using UnityEngine;
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
       _connectUseCase.Connect(ip, port);
    }

    public void StartHost(string ip, string port)
    {
        _connectUseCase.StartHost(ip, port);
    }

}
