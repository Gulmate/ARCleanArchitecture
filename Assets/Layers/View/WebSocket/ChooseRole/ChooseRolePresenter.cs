using System;
using UnityEngine;
using System.Net.WebSockets;
using VContainer;

public delegate void ConnectionStatusChangedHandler(WebSocketEnums.ConnectionStatus status, WebSocketEnums.ConnectionType connectionType);
public class ChooseRolePresenter : MonoBehaviour
{
    public event ConnectionStatusChangedHandler ConnectionStatusChanged;

    private WebSocketStreamingClientUsecase _usecase;

    [Inject]
    private WebSocketStreamingClientService _service;
    [Inject]
    private WebSocketClientService _webSocketClientService;

    [Inject]
    void Awake()
    {
        _usecase = new WebSocketStreamingClientUsecase(_service, _webSocketClientService);
    }
    public void JoinAsViewer()
    {
        _usecase.ConnectToStreamingAsViewer();
    }

    internal void JoinAsStreamer()
    {
        _usecase.ConnectToStreamingAsStreamer();
    }
    void Start()
    {
        OnConnectionStatusChanged(_usecase.GetCurrentConnectionStatus());
        _usecase.OnConnectionStatusChanged(OnConnectionStatusChanged);
    }
    private void OnConnectionStatusChanged(WebSocketEnums.ConnectionStatus status)
    {
        // Notify subscribers about the connection status change
        ConnectionStatusChanged?.Invoke(status, _usecase.GetCurrentConnectionType());
    }
    public (WebSocketEnums.ConnectionStatus, WebSocketEnums.ConnectionType) GetCurrentConnectionStatusAndType()
    {
        return (_usecase.GetCurrentConnectionStatus(), _usecase.GetCurrentConnectionType());
    }
}