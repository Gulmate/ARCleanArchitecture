using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VContainer;

public class ChooseRoleView : MonoBehaviour
{
    [Inject]
    ChooseRolePresenter _presenter;

    [SerializeField]
    private Button _joinAsStreamerButton;
    [SerializeField]
    private Button _joinAsViewerButton;
    [SerializeField]
    private Button _loadStreamerButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (_joinAsStreamerButton != null)
        {
            _joinAsStreamerButton.onClick.AddListener(OnJoinAsStreamerButtonClicked);
            _loadStreamerButton.onClick.AddListener(()=> SceneManager.LoadScene("WebRTCStreamerScene"));
        }
        else
        {
            Debug.LogError("Join As Streamer Button is not assigned in the inspector.");
        }
        if (_joinAsViewerButton != null)
        {
            _joinAsViewerButton.onClick.AddListener(OnJoinAsViewerButtonClicked);
        }
        else
        {
            Debug.LogError("Join As Viewer Button is not assigned in the inspector.");
        }
        _joinAsStreamerButton.interactable = false;
        _joinAsViewerButton.interactable = false;
        if(_presenter != null)
        {
            var connectionStatusAndType = _presenter.GetCurrentConnectionStatusAndType();
            OnConnectionStatusChanged(connectionStatusAndType.Item1, connectionStatusAndType.Item2);
            _presenter.ConnectionStatusChanged += OnConnectionStatusChanged;
        }
        else
        {
            Debug.LogError("ChooseRolePresenter is not injected properly.");
        }
    }

    private void OnJoinAsViewerButtonClicked()
    {
        _presenter.JoinAsViewer();
    }

    private void OnJoinAsStreamerButtonClicked()
    {
        _presenter.JoinAsStreamer();
    }
    private void OnConnectionStatusChanged(WebSocketEnums.ConnectionStatus connectionStatus, WebSocketEnums.ConnectionType connectionType)
    {
        switch (connectionStatus)
        {
            case WebSocketEnums.ConnectionStatus.NotConnected:
                _joinAsStreamerButton.interactable = true;
                _joinAsViewerButton.interactable = true;
                break;
            case WebSocketEnums.ConnectionStatus.ConnectionRequested:
                _joinAsStreamerButton.interactable = false;
                _joinAsViewerButton.interactable = false;
                break;
            case WebSocketEnums.ConnectionStatus.Connected:
                _joinAsStreamerButton.interactable = false;
                _joinAsViewerButton.interactable = false;
                //TODO:MOVE Redirect to streamer or viewer screen based on connection type 
                if (connectionType==WebSocketEnums.ConnectionType.Streamer)
                {
                    //Redirect to streamer screen
                    Debug.Log("Redirecting to streamer screen");
                    SceneManager.LoadScene("WebRTCStreamerScene");
                }
                else if(connectionType == WebSocketEnums.ConnectionType.Viewer)
                {
                    //Redirect to viewer screen
                    Debug.Log("Redirecting to viewer screen");
                    SceneManager.LoadScene("WebRTCViewerScene");
                }
                break;
            case WebSocketEnums.ConnectionStatus.ConnectionFailed:
                _joinAsStreamerButton.interactable = true;
                _joinAsViewerButton.interactable = true;
                break;
        }
    }
    private void OnDestroy()
    {
        if (_joinAsStreamerButton != null)
        {
            _joinAsStreamerButton.onClick.RemoveListener(OnJoinAsStreamerButtonClicked);
        }
        if (_joinAsViewerButton != null)
        {
            _joinAsViewerButton.onClick.RemoveListener(OnJoinAsViewerButtonClicked);
        }
    }
}
