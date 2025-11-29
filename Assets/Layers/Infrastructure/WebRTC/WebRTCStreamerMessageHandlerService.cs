using System;
using Unity.WebRTC;
using UnityEngine;


public class WebRTCStreamerMessageHandlerService
{
    private WebSocketClientService _webSocketClientService;
    private WebSocketStreamingClientService _webSocketStreamingClientService;
    public event DisplayMessageHandler DisplayDebugMessage;
    private static int sdpType = 420;
    private static int iceType = 210;

    private static WebRTCStreamerMessageHandlerService _instance;
    public void SetServices(WebSocketClientService webSocketClientService, WebSocketStreamingClientService webSocketStreamingClientService, WebRTCStreamerService webRTCStreamerService)
    {
        if (_instance == null)
        {
            _instance = new WebRTCStreamerMessageHandlerService();
            _instance._webSocketClientService = webSocketClientService;
            _instance._webSocketStreamingClientService = webSocketStreamingClientService;
            _instance.SubscribeToWebScoketMessages();
            _instance.SubscribeToWebRTCStreamerMessages();
        }
    }

    private void SubscribeToWebScoketMessages()
    {
        _webSocketClientService.Instance.MessageReceived += WebSocketMessageRecived;
    }
    private void SubscribeToWebRTCStreamerMessages()
    {
        WebRTCStreamerService.Instance.OnIceCandidateGenerated += (viewerId, iceCandidate) =>
        {
            SendICEMessage(iceCandidate, viewerId);
        };
        WebRTCStreamerService.Instance.OnOfferCreated += (viewerId, offer) =>
        {
            SendSDPMessage(offer, viewerId);
        };
    }

    private void SendSDPMessage(RTCSessionDescription offer, string viewerId)
    {
        uint pairID = viewerId != null ? Convert.ToUInt32(viewerId) : 0;
        var message = JsonUtility.ToJson(offer);
        _webSocketStreamingClientService.SendWebSocketMessageToPairClientWithID(message, sdpType, pairID);
    }

    private void SendICEMessage(RTCIceCandidate iceCandidate, string viewerId)
    {
        uint pairID = viewerId != null ? Convert.ToUInt32(viewerId) : 0;
        RTCIceCandidateInit rTCIceCandidateInit = new RTCIceCandidateInit
        {
            candidate = iceCandidate.Candidate,
            sdpMid = iceCandidate.SdpMid,
            sdpMLineIndex = iceCandidate.SdpMLineIndex,
        };
        var message = JsonUtility.ToJson(rTCIceCandidateInit);
        _webSocketStreamingClientService.SendWebSocketMessageToPairClientWithID(message, iceType,pairID); ;
    }


    private void WebSocketMessageRecived(string message)
    {
        var wrappedMessage = DTOMessageWrapper.ConvertFromMessage(message);
        if (wrappedMessage == null)
        {
            DisplayDebugMessage?.Invoke("Failed to parse message: " + message);
            return;
        }
        if ((WebSocketEnums.AnswerType)wrappedMessage.Type == WebSocketEnums.AnswerType.Relayed)
        {
            var relayedMessage = wrappedMessage.Payload;

            int viewerId = relayedMessage.Type / 1000;
            int originalType = relayedMessage.Type % 1000;
            switch (originalType)
            {
                case var type when type == sdpType:
                    var sdp = JsonUtility.FromJson<RTCSessionDescription>(relayedMessage.Message);
                    WebRTCStreamerService.Instance.ReceiveAnswer(viewerId.ToString(), sdp);
                    break;
                case var type when type == iceType:
                    var iceCandidateInit = JsonUtility.FromJson<RTCIceCandidateInit>(relayedMessage.Message);
                    RTCIceCandidate iceCandidate = new RTCIceCandidate(iceCandidateInit);
                    WebRTCStreamerService.Instance.AddIceCandidate(viewerId.ToString(), iceCandidate);
                    break;
                default:
                    DisplayDebugMessage?.Invoke("Message type not for rtc: " + relayedMessage.Type);
                    break;
            }
        }
    }


}
