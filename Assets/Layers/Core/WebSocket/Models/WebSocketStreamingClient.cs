public class WebSocketStreamingClient
{

    public int IDOnServer { get; set; } = -1;
    public uint _pairID { get; set; } = 0;
    public bool IsPaired => _pairID != 0;
    public WebSocketEnums.ConnectionType ConnectionType { get; set; } = WebSocketEnums.ConnectionType.None;
    public WebSocketEnums.ConnectionStatus ConnectionToStreamingStatus { get; set; } = WebSocketEnums.ConnectionStatus.NotConnected;

}

