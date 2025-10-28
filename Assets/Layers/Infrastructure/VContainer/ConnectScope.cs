using VContainer;
using VContainer.Unity;

public class ConnectScope: LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<ConnectView>();
        

        builder.RegisterComponentOnNewGameObject<ConnectPresenter>(Lifetime.Scoped, "ConnectPresenter");
        builder.RegisterComponentOnNewGameObject<CustomNetworkManager>(Lifetime.Scoped, "NetworkManager");
    }
}