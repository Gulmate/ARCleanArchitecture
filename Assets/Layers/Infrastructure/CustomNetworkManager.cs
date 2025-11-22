using UnityEngine;
using Mirror;
using TMPro;
using UnityEngine.SceneManagement;

public class CustomNetworkManager : NetworkManager
{
    public override void Awake()
    {
        TelepathyTransport telepathy = gameObject.AddComponent<TelepathyTransport>();
        transport = telepathy;
        Transport.active = telepathy;

        base.Awake();

        autoCreatePlayer = false;
    }

    public void StartHostFromInput(string ipInput, string portInput)
    {
        if (ipInput== null || portInput == null) return;
        
        networkAddress = ipInput;
        if (ushort.TryParse(portInput, out ushort port))
        {
            if (transport is TelepathyTransport telepathy)
                telepathy.port = port;
            
            StartHost();
        }
        else
        {
            Debug.LogError("Invalid port number");
        }
    }

    public void Connect(string ipInput, string portInput)
    {
        if (ipInput == null || portInput == null) return;

        networkAddress = ipInput;

        if (ushort.TryParse(portInput, out ushort port))
        {
            if (transport is TelepathyTransport telepathy)
                telepathy.port = port;

            StartClient();
        }
        else
        {
            Debug.LogError("Invalid port number");
        }
    }

    public void Disconnect()
    {
        if (!isNetworkActive) return;

        if (mode == NetworkManagerMode.Host)
            StopHost();
        else if (mode == NetworkManagerMode.ServerOnly)
            StopServer();
        else
            StopClient();
    }


    public override void OnStartHost()
    {
        base.OnStartHost();
        SceneManager.LoadScene("ARClient");
    }
    public override void OnClientConnect()
    {
        base.OnClientConnect();

        if (mode == NetworkManagerMode.ClientOnly)
        {
            SceneManager.LoadScene("Scenes/Connection");
        }
    }

    public override void OnClientChangeScene(string newSceneName, SceneOperation sceneOperation, bool customHandling)
    {
        if (mode == NetworkManagerMode.ClientOnly)
        {
            return;
        }

        base.OnClientChangeScene(newSceneName, sceneOperation, customHandling);
    }
}