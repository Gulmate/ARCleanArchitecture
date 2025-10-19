using Unity.WebRTC;
using UnityEngine;
using VContainer;

public delegate void VideoStreamReceivedHandler(VideoStreamTrack videoStreamTrack);
public class WebRTCViewerPresenter : MonoBehaviour
{


    private WebRTCViewingUsecase _usecase;

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
        _usecase = new WebRTCViewingUsecase(_webSocketClientService, _webSocketStreamingClientService, _webRTCMessageHandlerService, _webRTCService);
    }

    public event VideoStreamReceivedHandler VideoStreamReceived;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        _usecase.OnVideoStreamReceived(OnVideoStreamReceived);


    }

    private void OnVideoStreamReceived(VideoStreamTrack videoStreamTrack)
    {
        if (videoStreamTrack != null)
        {
            VideoStreamReceived?.Invoke(videoStreamTrack);
        }
        else
        {
            Debug.LogError("Video Stream is not assigned in the inspector.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
