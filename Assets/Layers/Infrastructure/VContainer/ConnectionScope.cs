using VContainer;
using VContainer.Unity;

public class ConnectionScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<SessionView>();
        var networkManager = FindFirstObjectByType<CustomNetworkManager>();
        if (networkManager != null)
        {
            builder.RegisterComponent(networkManager);
        }

        builder.Register<SessionPresenter>(Lifetime.Scoped).AsSelf();
    }
}
