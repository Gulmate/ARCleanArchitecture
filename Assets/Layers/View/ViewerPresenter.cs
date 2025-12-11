using VContainer;

public class ViewerPresenter
{
    private ViewerUseCase useCase;


    [Inject]
    public ViewerPresenter(IDocumentationLogger logger, CustomNetworkManager networkManager)
    {
        useCase = new ViewerUseCase(logger, networkManager);
    }

    public void SendMessage()
    {
        useCase.SendMessage();
    }
}