using UnityEngine;
using Mirror;
using TMPro;
using UnityEngine.SceneManagement;

public class CustomNetworkManager : NetworkManager
{
    [SerializeField]
    private TMP_InputField addressInputField;

    [SerializeField]
    private TMP_InputField portInputField;

    public override void Awake()
    {
        base.Awake();
        autoCreatePlayer = false;
    }

    public void StartHostFromInput()
    {
        if (addressInputField == null || portInputField == null) return;

        networkAddress = addressInputField.text;

        if (ushort.TryParse(portInputField.text, out ushort port))
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

    public void Connect()
    {
        if (addressInputField == null || portInputField == null) return;

        networkAddress = addressInputField.text;

        if (ushort.TryParse(portInputField.text, out ushort port))
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

    // HOST starts with ARClient scene
    public override void OnStartHost()
    {
        base.OnStartHost();

        // only host switches to ARClient
        SceneManager.LoadScene("ARClient");
    }

    // CLIENTS connect but stay in their own scene
    public override void OnClientConnect()
    {
        base.OnClientConnect();

        if (mode == NetworkManagerMode.ClientOnly)
        {
            // ensure they stay in Connection scene
            SceneManager.LoadScene("Connection");
        }
    }

    // Prevent Mirror’s automatic scene sync for clients
    public override void OnClientChangeScene(string newSceneName, SceneOperation sceneOperation, bool customHandling)
    {
        if (mode == NetworkManagerMode.ClientOnly)
        {
            Debug.Log($"Client ignoring automatic scene change to {newSceneName}");
            // we handle our own scene switching, so skip Mirror's logic
            // (do not call base.OnClientChangeScene)
            return;
        }

        base.OnClientChangeScene(newSceneName, sceneOperation, customHandling);
    }
}