
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using VContainer;
using Unity.WebRTC;


public delegate void JobDone();
public class WebRTCStreamerPresenter : MonoBehaviour
{

    public event JobDone ConnectionStabilized;

    private WebRTCStreamingUsecase _usecase;


    [Inject]
    private WebSocketStreamingClientService _webSocketStreamingClientService;
    [Inject]
    private WebSocketClientService _webSocketClientService;
    [Inject]
    private WebRTCService _webRTCService;
    [Inject]
    private WebRTCMessageHandlerService _webRTCMessageHandlerService;

    [Inject]
    void Awake()
    {
        _usecase = new WebRTCStreamingUsecase(_webSocketClientService, _webSocketStreamingClientService, _webRTCMessageHandlerService, _webRTCService);
    }

    void Start()
    {
        _usecase.PairUpDone(Connect);
        
    }
    void Update()
    {
        if (_ConnectionDone)
        {
            if (_usecase.GetSignalingState() == RTCSignalingState.Stable)
            {
                _ConnectionDone = false;
                ConnectionStabilized?.Invoke();
            }
        }
    }
    //After pairing up with viewer, connect WebRTC
    private void Connect()
    {
        _usecase.OnConnectionDone(() => _ConnectionDone = true);
        _usecase.Connect();
    }

    private bool _ConnectionDone = false;
    private string _viewerId = "";
    public List<string> Refresh()
    {
        return GetViewers().Result; 
    }
    private async Task<List<string>> GetViewers()
    {
        var answ = _usecase.GetPossibleViewersTask();
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
            _usecase.PairUp(viewerIdInt);
            _viewerId = viewerID;
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
        _usecase.SendVideoTrack(videoStreamTrack);
    }
    public string GetViewerId()
    {
        return _viewerId;
    }
}