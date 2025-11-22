using UnityEngine;
using Mirror;
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
        offlineScene = "Mirror";
    }

    public void StartServerFromInput(string ipInput, string portInput)
    {
        if (ipInput== null || portInput == null) return;
        
        networkAddress = ipInput;

        

        if (ushort.TryParse(portInput, out ushort port))
        {
            if (transport is TelepathyTransport telepathy)
                telepathy.port = port;
            
            StartServer();
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

    public override void OnStartServer()
    {
        base.OnStartServer();
        
        if (mode == NetworkManagerMode.ServerOnly)
        {
            Debug.Log("Dedicated server started — loading ServerScene");
            SceneManager.LoadScene("ServerScene");
        }
    }

    public override void OnClientConnect()
    {
        base.OnClientConnect();

        if (mode == NetworkManagerMode.ClientOnly)
        {
            SceneManager.LoadScene("Scenes/Connection");
        }
    }

    public void ChangeSceneToStream()
    {
        SceneManager.LoadScene("Scenes/ARClient");
    }

    public void ChangeSceneToView()
    {
        SceneManager.LoadScene("Scenes/ViewerClient");
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