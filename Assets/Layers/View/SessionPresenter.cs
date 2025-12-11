using System.Collections.Generic;
using VContainer;

public class SessionPresenter
{
    private SessionUseCase useCase;

    [Inject]
    public SessionPresenter(IDocumentationLogger logger, CustomNetworkManager networkManager)
    {
        useCase = new SessionUseCase(logger, networkManager);
    }

    public void ChangeToStream()
    {
        useCase.ChangeToStream();
    }

    public void ChangeToView(int id)
    {
        useCase.ChangeToView(id);
    }

    public List<SessionInfo> UpdateSessionList()
    {
        return useCase.GetSessionList();
    }
}