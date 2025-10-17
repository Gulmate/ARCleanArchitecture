using System;
using VContainer;
using WebSocketSharp;
public class WebSocketClientUsecase
{
    private readonly WebSocketClientService _webSocketClientService;
    [Inject]
    public WebSocketClientUsecase(WebSocketClientService webSocketClientService)
    {
        this._webSocketClientService = webSocketClientService;
    }
    public int Connect(string serverIp, string serverPort)
    {
        int serverPortInt;
        if(!int.TryParse(serverPort, out serverPortInt))
            serverPortInt = 8080;
        if (serverPortInt < 1 || serverPortInt > 65535)
            serverPortInt = 8080;
        _webSocketClientService.Connect(serverIp, serverPortInt);
        return serverPortInt;
    }
    public void Disconnect()
    {
        _webSocketClientService.Disconnect();
    }
    public void SendMessage(string message)
    {
        _webSocketClientService.SendMessage(message);
    }
    public void SendMessage(DTOMessageWrapper dTOMessage)
    {
        string message = new DTOMessageWrapperUsecase().ConvertToMessage(dTOMessage);
        SendMessage(message);
    }
    public void SendMessageToServer(DTOMessageWrapper dTOMessage)
    {
        DTOMessageWrapper dTOMessageToSend = new DTOMessageWrapper
        {
            Type = (int)WebSocketEnums.MessageType.ToServer,
            Payload = dTOMessage
        };
        SendMessage(dTOMessageToSend);
    }

    public void SendMessageToClient(DTOMessageWrapper dTOMessage)
    {
        DTOMessageWrapper dTOMessageToSend = new DTOMessageWrapper
        {
            Type = (int)WebSocketEnums.MessageType.ToOtherClient,
            Payload = dTOMessage
        };
        SendMessage(dTOMessageToSend);
    }

    public void onWebSocketStateChange(Action<WebSocketState> listener)
    {
        _webSocketClientService.ConnectionStatusChanged += delegate (WebSocketState state)
        {
            listener(state);
        };
    }

}
