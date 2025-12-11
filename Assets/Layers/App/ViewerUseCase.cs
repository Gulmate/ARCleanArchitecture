public class ViewerUseCase
{
    private IDocumentationLogger logger;
    private CustomNetworkManager networkManager;

    public ViewerUseCase(IDocumentationLogger logger, CustomNetworkManager networkManager)
    {
        this.logger = logger;
        this.networkManager = networkManager;
    }

    public void SendMessage()
    {
        networkManager.SendTargetedMessage("Hello from Viewer!");
    }
}