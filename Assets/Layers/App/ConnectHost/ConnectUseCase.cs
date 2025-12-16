
public class ConnectUseCase
{
    private INetworkManager _networkManager;

    public void Connect(string ip, string port)
    {
        _networkManager.Connect(ip, port);
    }
    public void StartHost(string ip, string port)
    {
        _networkManager.StartServerFromInput(ip, port);
    }

    public void SetToOnline(INetworkManager networkManager)
    {
        _networkManager = networkManager;
    }
}