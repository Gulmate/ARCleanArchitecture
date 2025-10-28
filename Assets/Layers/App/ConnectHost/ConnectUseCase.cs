public class ConnectUseCase
{
    private readonly CustomNetworkManager _networkManager;
    public ConnectUseCase(CustomNetworkManager networkManager)
    {
        _networkManager = networkManager;
    }
    public void Connect(string ip, string port)
    {
        _networkManager.Connect(ip, port);
    }
    public void StartHost(string ip, string port)
    {
        _networkManager.StartHostFromInput(ip, port);
    }
}