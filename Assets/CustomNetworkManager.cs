using UnityEngine;
using Mirror;
using TMPro;


public class CustomNetworkManager : MonoBehaviour
{
    [SerializeField]
    private NetworkManager manager;

    [SerializeField]
    private TMP_InputField addressInputField;

    [SerializeField]
    private TMP_InputField portInputField;

    [SerializeField]
    private TelepathyTransport transport;

    public void StartServer()
    {

        if (addressInputField != null && portInputField != null)
        {
            manager.networkAddress = addressInputField.text;
            transport.Port = ushort.Parse(portInputField.text);


            manager.StartHost();
        }
        return;
    }

    public void Connect()
    {
        if (addressInputField != null && portInputField != null)
        {
            string address = addressInputField.text;
            transport.Port = ushort.Parse(portInputField.text);
            manager.StartClient();
        }
        return;
    }

    public void Disconnect()
    {
        if (manager.isNetworkActive)
        {
            manager.StopClient();
        }
    }


}
