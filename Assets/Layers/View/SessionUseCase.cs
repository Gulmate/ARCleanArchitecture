using System;
using System.Collections.Generic;
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
        networkManager.HostSession("random");
    }

    public void ChangeToView(int id)
    {
        logger.LogToJSON("User choose viewing", LogLevel.User);
        networkManager.ChangeSceneToView();
        networkManager.JoinSession(id);
    }

    public List<SessionInfo> GetSessionList()
    {
        return  networkManager.GetSessions();
    }
}