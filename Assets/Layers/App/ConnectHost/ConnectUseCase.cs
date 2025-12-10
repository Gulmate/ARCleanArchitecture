using Mirror;
using System;

public class ConnectUseCase
{
    private CustomNetworkManager _networkManager;
    private readonly IDocumentationLogger _documentationLogger;
    string sessionName;
    public ConnectUseCase(IDocumentationLogger logger)
    {
        
        _documentationLogger = logger;
    }
    public void Connect(string ip, string port)
    {
        _networkManager.Connect(ip, port);
    }
    public void StartHost(string ip, string port)
    {
        _networkManager.StartServerFromInput(ip, port);
    }

    public void SetToOnline(CustomNetworkManager networkManager)
    {
        _networkManager = networkManager;
    }

    public void loggerSetup(string dataPath)
    {
        sessionName = $"session{DateTime.Now.ToString().Replace(" ", "").Replace(":", "-")}";
        _documentationLogger.setZipPath($"{dataPath}/{sessionName}.zip");
    }
}