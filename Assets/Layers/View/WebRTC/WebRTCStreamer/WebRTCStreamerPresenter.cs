
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using VContainer;
using Unity.WebRTC;

public class WebRTCStreamerPresenter : MonoBehaviour
{

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

    void Start()
    {
        _refreshButton.onClick.AddListener(Refresh);
        _callButton.onClick.AddListener(Call);
        _startStreamButton.onClick.AddListener(OnStartStream);
        _webSocketStreamingClient.PaierUpDone += Connect;
    }
    void Update()
    {
        if (_ConnectionDone)
        {
            if (_webRTCManager.SignalingState == RTCSignalingState.Stable)
            {
                _ConnectionDone = false;
                _maintext.SetText("Connected to:" + _viewerId);
                _startStreamButton.interactable = true;
            }
        }
    }
    public void Connect()
    {
        _webRTCManager = WebRTCManager.Instance;
        _webRTCManager.Negotiate();
        _webRTCManager.Connected += (() => _ConnectionDone = true);
    }

    private WebSocketClientScript _webSocketClient = WebSocketClientScript.Instance;
    private WebSocketStreamingClientScript _webSocketStreamingClient = WebSocketStreamingClientScript.Instance;
    private WebRTCManager _webRTCManager = WebRTCManager.Instance;
    private bool _ConnectionDone = false;
    public List<string> Refresh()
    {
        if (_webSocketClient != null)
        {
            return GetViewers().Result; 
        }
        else
        {
            Debug.LogError("WebSocketClientScript instance is null.");
            return null;
        }
    }
    private async Task<List<string>> GetViewers()
    {
        var answ = _webSocketStreamingClient.GetPossibleViewersTask();
        var result = await answ;
        if (result != null)
        {
            if (result.Count == 0)
            {
                return null;
            }
            else
            {
                Debug.Log("Result first: " + result[0]);
                var stringResult = result.ConvertAll(viewerId => viewerId.ToString());
                return stringResult;
            }
        }
        return null;
    }
    public void Call(string viewerID)
    {


        if (uint.TryParse(viewerID, out uint viewerIdInt))
        {
            _webSocketStreamingClient.PairUp(viewerIdInt);
        }
        else
        {
            Debug.LogError("Failed to parse viewer ID: " + viewerID);
        }

    }
    public void StartStream(Camera camera)
    {

        var videoStreamTrack = camera.CaptureStreamTrack(1280, 720);
        //var videoStreamTrack = _camera.CaptureStreamTrack(640, 360);
        _webRTCManager.SendVideoTrack(videoStreamTrack);
    }
}