using UnityEngine;

public class SessionUseCase
{
    private IDocumentationLogger logger;
    private CustomNetworkManager networkManager;

    public SessionUseCase(IDocumentationLogger logger, CustomNetworkManager networkManager)
    {
        this.logger = logger;
        this.networkManager = networkManager;
    }

    public void ChangeToStream()
    {
        logger.LogToJSON("User choose streaming", LogLevel.User);
        networkManager.ChangeSceneToStream();
    }

    public void ChangeToView()
    {
        logger.LogToJSON("User choose viewing", LogLevel.User);
        networkManager.ChangeSceneToView();
    }
}