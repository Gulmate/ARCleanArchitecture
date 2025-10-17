using System;
using UnityEngine;
using System.Net.WebSockets;

public delegate void ConnectionStatusChangedHandler(WebSocketEnums.ConnectionStatus status, WebSocketEnums.ConnectionType connectionType);
public class ChooseRolePresenter : MonoBehaviour
{
    public event ConnectionStatusChangedHandler ConnectionStatusChanged;
    [SerializeField]
    //TODO:
    private WebSocketStreamingClientScript _webSocketStreamingClient = WebSocketStreamingClientScript.Instance;
    //TODO: ADD events for connection status change


    public void JoinAsViewer()
    {
        throw new NotImplementedException();
        _webSocketStreamingClient.ConnecToStreaming(WebSocketEnums.ConnectionType.Viewer);
    }

    internal void JoinAsStreamer()
    {
        throw new NotImplementedException();
        _webSocketStreamingClient.ConnecToStreaming(WebSocketEnums.ConnectionType.Streamer);
    }
    void Start()
    {

        if (_webSocketStreamingClient == null)
        {
            _webSocketStreamingClient = WebSocketStreamingClientScript.Instance;
        }

        OnConnectionStatusChanged(_webSocketStreamingClient.ConnectionToStreamingStatus);
        _webSocketStreamingClient.ConnectionStatusChanged += OnConnectionStatusChanged;
    }
    private void OnConnectionStatusChanged(WebSocketEnums.ConnectionStatus status)
    {
        // Notify subscribers about the connection status change
        ConnectionStatusChanged?.Invoke(status, _webSocketStreamingClient.CurrentConnectionType);

    }
}